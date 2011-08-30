//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE.
//
//  This material may not be duplicated in whole or in part, except for 
//  personal use, without the express written consent of the author. 
//
//  Email:  paul.caponetti@gmail.com
//
//  Copyright (C) 2006-2008 Ianier Munoz. All Rights Reserved.

using System;
using System.Collections;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;

namespace PClapper
{
	/// <summary>
	/// Summary description for Listener.
	/// </summary>
	public class Listener
	{

        // Objects
		ArrayList listeners = new ArrayList();
        private WaveLib.WaveInRecorder recorder;
        private byte[] recBuffer;
        private Queue<byte> previousValues = new Queue<byte>(10);

        // Variables
        private long sampleCount = 0;
        private long lastPeak = 0;
        private long now = 0;
        private byte lastSample = 0;
        private float ambiantNoise = 0;
        private int adjustedSensitivity = 0;
        private int h;

        // Constants dervied from settings
        private long minDelay;
        private int maxSamples;
        private long noiseMesurementPeriod;
        private int sensitivity;
        private bool adapt;
        private int levelMax;
        private float avgPeakRatio;
        

        public Listener() {
        }

		public void DataArrived(IntPtr data, int size)
		{
            if (recBuffer == null || recBuffer.Length < size)
                recBuffer = new byte[size];
            System.Runtime.InteropServices.Marshal.Copy(data, recBuffer, 0, size);
			
			// Clap recognition alogrithm
			for(h = 0; h < size ; h += 1) 
			{
                ambiantNoise += (Math.Abs(levelMax / 2F - recBuffer[h]) - ambiantNoise) / noiseMesurementPeriod;

                if (recBuffer[h] < lastSample)
                    previousValues.Clear();
                else if (previousValues.Count >= maxSamples)
                    previousValues.Dequeue();

                previousValues.Enqueue(recBuffer[h]);
                lastSample = recBuffer[h];

                adjustedSensitivity = adapt ? Math.Min(sensitivity, (int)(levelMax / 2F - ambiantNoise * avgPeakRatio)) : sensitivity;

                if (previousValues.Peek() < levelMax / 2 && recBuffer[h] >= levelMax - adjustedSensitivity) {
                    now = sampleCount + h;
                    if (now - lastPeak > minDelay) clap(now);
                    lastPeak = now;
				}
			}
            sampleCount += size;
            //System.Diagnostics.Debug.WriteLine(ambiantNoise);
        }

		public void Stop() {
            if (recorder == null) return;

            try {
                recorder.Dispose();
            }
            catch (Exception e) {
                Stop();
                MessageBox.Show(e.Message);
            }
            finally {
                recorder = null;
            }
		}

        private void refreshSettings() {
            minDelay = (Properties.Settings.Default.minimumDelay * Properties.Settings.Default.samplingRate) / 1000;
            maxSamples = Properties.Settings.Default.maxSamples;
            noiseMesurementPeriod = Properties.Settings.Default.noiseMesurementPeriod * Properties.Settings.Default.samplingRate;
            sensitivity = Properties.Settings.Default.breaker;
            adapt = Properties.Settings.Default.adaptToBackground;
            levelMax = (int)Math.Pow(2,Properties.Settings.Default.samplingFormat) - 1;
            avgPeakRatio = Properties.Settings.Default.avgPeakRatio;
        }

		public void Start() {
			Stop();
            refreshSettings();
			try	{
				WaveLib.WaveFormat fmt = new WaveLib.WaveFormat(
                    Properties.Settings.Default.samplingRate, 
                    Properties.Settings.Default.samplingFormat,
                    1);
                int device = PClapper.Properties.Settings.Default.inputDevice;
                recorder = new WaveLib.WaveInRecorder(
                    device, fmt, 
                    Properties.Settings.Default.bufferLength, 
                    Properties.Settings.Default.numBuffers, 
                    new WaveLib.BufferDoneEventHandler(DataArrived)
                    );
			}
			catch(Exception e) {
				Stop();
				MessageBox.Show(e.Message);
			}
		}

		public void clap(long sampleCount) {
			foreach (object item in listeners) {
                ((ClapListener)item).clapActionPerformed(sampleCount);
			}
		}

		public void addClapListener(ClapListener c) {
			listeners.Add (c);
		}
	}
}
