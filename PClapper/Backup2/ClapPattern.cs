using System;
using System.Collections.Generic;
using System.Text;
using System.Media;
using System.Timers;
using System.ComponentModel;
using System.Globalization;
using System.Diagnostics;

namespace PClapper {

    public class ClapsSample {
        public List<long> claps = new List<long>();
        public ClapsSample(List<long> claps) {
            this.claps = claps;
        }
        public ClapsSample() {
        }
    }

    [Serializable]
    public class ClapPattern {

        public List<int> claps = new List<int>();

        public ClapPattern(List<int> claps) {
            this.claps = claps;
        }
        
        public ClapPattern() {
        }

        public void Play() {
            SoundPlayer sp = new SoundPlayer(Properties.Resources.clap);
            sp.Load();
            foreach (int clapPos in claps) {
                int tempo = (int)Properties.Settings.Default.tempo;
                Timer t = new Timer(10 + (clapPos * 30000) / tempo);
                t.AutoReset = false;
                t.Elapsed += (object sender, ElapsedEventArgs e) => sp.Play();
                t.Start();
            }
        }

        public int longestSilence {
            get {
                int max=0;
                for(int i=1; i < claps.Count; i++) {
                    max = Math.Max(max, claps[i] - claps[i-1]);
                }
                return max;
            }
        }

        public bool isSubPatternOf(ClapPattern p) {
            if (claps.Count >= p.claps.Count)
                return false;
            for (int i=0; i<claps.Count; i++)
                if (claps[i] != p.claps[i])
                    return false;
            return true;
        }

        public int tempo(ClapsSample sample) {
            long sampleLength = sample.claps[sample.claps.Count - 1] - sample.claps[0];
            int patternLength = claps[claps.Count - 1] - claps[0];
            if (sampleLength == 0) return 0;
            return (int)(Properties.Settings.Default.samplingRate * 30 * patternLength / sampleLength);
        }

        public bool match(ClapsSample sample) {
            // Count check
            if (sample.claps.Count != claps.Count) return false;

            if (sample.claps.Count == 1) return true;

            // Rythm check
            if (!PClapper.Properties.Settings.Default.checkRythm) return true;
            long sampleLength = sample.claps[sample.claps.Count - 1] - sample.claps[0];
            int patternLength = claps[claps.Count - 1] - claps[0];
            long beatLength = patternLength == 0 ? 0 : sampleLength / patternLength;
            long margin = (beatLength * (int)PClapper.Properties.Settings.Default.rythmTolerance) / 100;
            for (int i = 0; i < claps.Count; i++) {
                long theoreticalClap = sample.claps[0] + (claps[i] - claps[0]) * beatLength;
                if (Math.Abs(sample.claps[i] - theoreticalClap) > margin) {
                    Debug.WriteLine("Wrong rythm");
                    return false;
                }
            }

            // Tempo Check
            if (!PClapper.Properties.Settings.Default.checkTempo) return true;
            long theoreticalBeatLength = 30 * Properties.Settings.Default.samplingRate / (long)PClapper.Properties.Settings.Default.tempo;
            margin = (beatLength * (int)PClapper.Properties.Settings.Default.tempoTolerance) / 100;
            if (Math.Abs(beatLength - theoreticalBeatLength) > margin) {
                Debug.WriteLine("Wrong tempo");
                return false;
            }

            return true;
        }
    }
}
