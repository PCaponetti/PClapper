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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace PClapper
{
	/// <summary>
	/// Summary description for ClapActions.
	/// </summary>
	public class ActionsSettingsDialog : System.Windows.Forms.Form
	{
		public System.Windows.Forms.TreeView treeView;
		private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem menuItemAddPattern;
        private ToolStripMenuItem menuItemAddAction;
        private ToolStripMenuItem menuItemEditPattern;
        private ToolStripMenuItem menuItemDeletePattern;
        private ToolStripMenuItem menuItemEditAction;
        private ToolStripMenuItem menuItemDeleteAction;
        private ImageList imageList;
        private ToolStripSeparator toolStripSeparator1;
        private IContainer components;

		public ActionsSettingsDialog(ActionsSettings settings)
		{
			InitializeComponent();
            this.actionsSettings = settings.DeepClone();
            treeView.Nodes[0].ExpandAll();
		}

        public ActionsSettings actionsSettings {
            get {
                ActionsSettings result = new ActionsSettings();
                foreach (TreeNode node in treeView.Nodes[0].Nodes) {
                    ActionGroup ag = (ActionGroup)node.Tag;
                    ag.actions.Clear();
                    foreach (TreeNode n in node.Nodes) ag.actions.Add((ActionSetting)n.Tag);
                    result.addActionGroup(ag);
                }

                return result;
            }
            set {
                treeView.Nodes[0].Nodes.Clear();
                foreach (ActionGroup group in value.actionGroups) {
                    TreeNode node = new TreeNode(group.name);
                    node.Tag = group;
                    foreach (ActionSetting a in group.actions) {
                        TreeNode n = new TreeNode(a.action);
                        n.Tag = a;
                        n.SelectedImageIndex = 1;
                        n.ImageIndex = 1;
                        node.Nodes.Add(n);
                    }
                    treeView.Nodes[0].Nodes.Add(node);
                }
            }
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Patterns", 2, 2);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionsSettingsDialog));
            this.treeView = new System.Windows.Forms.TreeView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemAddAction = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEditPattern = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDeletePattern = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEditAction = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDeleteAction = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemAddPattern = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.ContextMenuStrip = this.contextMenuStrip;
            this.treeView.HideSelection = false;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList;
            this.treeView.Location = new System.Drawing.Point(8, 12);
            this.treeView.Name = "treeView";
            treeNode1.ImageIndex = 2;
            treeNode1.Name = "RootNode";
            treeNode1.SelectedImageIndex = 2;
            treeNode1.Text = "Patterns";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(272, 222);
            this.treeView.TabIndex = 1;
            this.treeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView_DragDrop);
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            this.treeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView_KeyDown);
            this.treeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_ItemDrag);
            this.treeView.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView_DragOver);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAddAction,
            this.menuItemEditPattern,
            this.menuItemDeletePattern,
            this.menuItemEditAction,
            this.menuItemDeleteAction,
            this.toolStripSeparator1,
            this.menuItemAddPattern});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(156, 142);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // menuItemAddAction
            // 
            this.menuItemAddAction.Name = "menuItemAddAction";
            this.menuItemAddAction.Size = new System.Drawing.Size(155, 22);
            this.menuItemAddAction.Text = "Add action";
            this.menuItemAddAction.Click += new System.EventHandler(this.menuItemAddAction_Click);
            // 
            // menuItemEditPattern
            // 
            this.menuItemEditPattern.Name = "menuItemEditPattern";
            this.menuItemEditPattern.Size = new System.Drawing.Size(155, 22);
            this.menuItemEditPattern.Text = "Edit pattern";
            this.menuItemEditPattern.Click += new System.EventHandler(this.menuItemEditPattern_Click);
            // 
            // menuItemDeletePattern
            // 
            this.menuItemDeletePattern.Name = "menuItemDeletePattern";
            this.menuItemDeletePattern.Size = new System.Drawing.Size(155, 22);
            this.menuItemDeletePattern.Text = "Delete pattern";
            this.menuItemDeletePattern.Click += new System.EventHandler(this.menuItemDeletePattern_Click);
            // 
            // menuItemEditAction
            // 
            this.menuItemEditAction.Name = "menuItemEditAction";
            this.menuItemEditAction.Size = new System.Drawing.Size(155, 22);
            this.menuItemEditAction.Text = "Edit action";
            this.menuItemEditAction.Click += new System.EventHandler(this.menuItemEditAction_Click);
            // 
            // menuItemDeleteAction
            // 
            this.menuItemDeleteAction.Name = "menuItemDeleteAction";
            this.menuItemDeleteAction.Size = new System.Drawing.Size(155, 22);
            this.menuItemDeleteAction.Text = "Delete action";
            this.menuItemDeleteAction.Click += new System.EventHandler(this.menuItemDeleteAction_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // menuItemAddPattern
            // 
            this.menuItemAddPattern.Name = "menuItemAddPattern";
            this.menuItemAddPattern.Size = new System.Drawing.Size(155, 22);
            this.menuItemAddPattern.Text = "Add pattern";
            this.menuItemAddPattern.Click += new System.EventHandler(this.menuItemAddPattern_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "pattern.png");
            this.imageList.Images.SetKeyName(1, "action.png");
            this.imageList.Images.SetKeyName(2, "folder.png");
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(124, 243);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(205, 243);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            // 
            // ActionsSettingsDialog
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(292, 278);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.buttonOk);
            this.Name = "ActionsSettingsDialog";
            this.Text = "Patterns & Actions";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


        private void contextMenuStrip_Opening(object sender, CancelEventArgs e) {
            TreeNode node = treeView.SelectedNode;
            int level = node==null ? -1 : node.Level;

            menuItemAddPattern.Visible    = level <= 0;
            menuItemAddAction.Visible     = level == 1;

            menuItemEditPattern.Visible   = level == 1;
            menuItemEditAction.Visible    = level == 2;
                
            menuItemDeletePattern.Visible = level == 1;
            menuItemDeleteAction.Visible  = level == 2;

            toolStripSeparator1.Visible   = false;

        }

        private void menuItemAddPattern_Click(object sender, EventArgs e) {
            ClapNodeOptions dialog = new ClapNodeOptions();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                ActionGroup group = dialog.actionGroup;
                TreeNode newNode = new TreeNode(group.name);
                newNode.Tag = group;
                treeView.Nodes[0].Nodes.Add(newNode);
                treeView.Nodes[0].Expand();
            }
            dialog.Dispose();
        }

        private void menuItemAddAction_Click(object sender, EventArgs e) {
            TreeNode node = treeView.SelectedNode;
            ClapActionOptions dialog = new ClapActionOptions();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                TreeNode newNode = new TreeNode();
                newNode.Tag = dialog.action;
                newNode.Text = ((ActionSetting)(newNode.Tag)).action;
                newNode.ImageIndex = 1;
                newNode.SelectedImageIndex = 1;
                node.Nodes.Add(newNode);
                node.Expand();
            }
            dialog.Dispose();
        }


        private void editNode(TreeNode node) {
            DialogResult result;
            switch (node.Level) {
                case 1:
                    ActionGroup group = (ActionGroup)node.Tag;
                    ClapNodeOptions dialogPattern = new ClapNodeOptions(group);
                    result = dialogPattern.ShowDialog();
                    if (result == DialogResult.OK) {
                        group = dialogPattern.actionGroup;
                        node.Text = group.name;
                        node.Tag = group;
                    }
                    dialogPattern.Dispose();
                    break;
                case 2:
                    ActionSetting action = (ActionSetting)node.Tag;
                    ClapActionOptions actionDialog = new ClapActionOptions(action);
                    result = actionDialog.ShowDialog();
                    if (result == DialogResult.OK) {
                        action = actionDialog.action;
                        node.Text = action.action;
                        node.Tag = action;
                    }
                    actionDialog.Dispose();
                    break;
                default: break;
            }
        }

        private void menuItemEditPattern_Click(object sender, EventArgs e) {
            editNode(treeView.SelectedNode);
        }

        private void menuItemEditAction_Click(object sender, EventArgs e) {
            editNode(treeView.SelectedNode);
        }

        private void deleteNode(TreeNode node) {
            switch (node.Level) {
                case 1:
                    if (MessageBox.Show(
                    "Are you sure you want to delete pattern '" + treeView.SelectedNode.Text + "' and all its associated actions?",
                    "Confirm", MessageBoxButtons.YesNo)
                    == DialogResult.Yes) {

                        treeView.Nodes[0].Nodes.Remove(node);
                    }
                    break;
                case 2:
                    if (
                        MessageBox.Show(
                        "Are you sure you want to delete action '" + treeView.SelectedNode.Text + "'?",
                        "Confirm", MessageBoxButtons.YesNo)
                        == DialogResult.Yes) {

                        treeView.Nodes[0].Nodes.Remove(node);
                    }
                    break;
                default: break;
            }
        }

        private void menuItemDeletePattern_Click(object sender, EventArgs e) {
            deleteNode(treeView.SelectedNode);
        }

        private void menuItemDeleteAction_Click(object sender, EventArgs e) {
            deleteNode(treeView.SelectedNode);
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
            treeView.SelectedNode = e.Node;
        }

        private void treeView_ItemDrag(object sender, ItemDragEventArgs e) {
            if (((TreeNode)e.Item).Level != 0) {
                treeView.SelectedNode = (TreeNode)e.Item;
                DoDragDrop(e.Item, DragDropEffects.Move | DragDropEffects.Copy | DragDropEffects.None);
            }
        }

        private void treeView_DragOver(object sender, DragEventArgs e) {
            TreeNode dstNode = treeView.GetNodeAt(treeView.PointToClient(new Point(e.X, e.Y)));
            TreeNode srcNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (!dstNode.IsExpanded && srcNode.Level == dstNode.Level + 1) dstNode.Expand();
            treeView.SelectedNode = dstNode;

            if (dstNode != null && dstNode != srcNode && 
                (srcNode.Level == dstNode.Level || srcNode.Level == dstNode.Level +1)) {

                if ((e.KeyState & 8) == 8)
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.Move;
            }
            else {
                e.Effect = DragDropEffects.None;
            }
        }
        
        private void treeView_DragDrop(object sender, DragEventArgs e) {
            TreeNode dstNode = treeView.GetNodeAt(treeView.PointToClient(new Point(e.X, e.Y)));
            TreeNode srcNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (e.Effect == DragDropEffects.None) return;
            if (dstNode == null || dstNode == srcNode) return;

            if (srcNode.Level == dstNode.Level + 1) {
                if (e.Effect == DragDropEffects.Move) 
                    srcNode.Remove();
                else
                    srcNode = (TreeNode)srcNode.Clone();
                dstNode.Nodes.Add(srcNode);
                dstNode.Expand();
                return;
            }

            if (srcNode.Level == dstNode.Level) {
                if (e.Effect == DragDropEffects.Move)
                    srcNode.Remove();
                else
                    srcNode = (TreeNode)srcNode.Clone();
                dstNode.Parent.Nodes.Insert(dstNode.Index, srcNode);
                return;
            }
        }

        private void treeView_KeyDown(object sender, KeyEventArgs e) {
            TreeNode node = treeView.SelectedNode;
            switch (e.KeyCode) {
                case Keys.Delete:
                    deleteNode(node);
                    break;
                case Keys.Enter:
                    if (e.Alt) editNode(node);
                    break;
                default: break;
            }
        }

	}
}
