namespace AppScan
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnstart = new System.Windows.Forms.Button();
            this.txtprot = new System.Windows.Forms.TextBox();
            this.txtxiancheng = new System.Windows.Forms.TextBox();
            this.labport = new System.Windows.Forms.Label();
            this.labmax = new System.Windows.Forms.Label();
            this.txtendip = new System.Windows.Forms.TextBox();
            this.txtstartip = new System.Windows.Forms.TextBox();
            this.labendip = new System.Windows.Forms.Label();
            this.labstartip = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtresult = new System.Windows.Forms.TextBox();
            this.progressip = new System.Windows.Forms.ProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnstart);
            this.groupBox1.Controls.Add(this.txtprot);
            this.groupBox1.Controls.Add(this.txtxiancheng);
            this.groupBox1.Controls.Add(this.labport);
            this.groupBox1.Controls.Add(this.labmax);
            this.groupBox1.Controls.Add(this.txtendip);
            this.groupBox1.Controls.Add(this.txtstartip);
            this.groupBox1.Controls.Add(this.labendip);
            this.groupBox1.Controls.Add(this.labstartip);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(648, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "扫描配置";
            // 
            // btnstart
            // 
            this.btnstart.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnstart.Location = new System.Drawing.Point(564, 25);
            this.btnstart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(65, 69);
            this.btnstart.TabIndex = 15;
            this.btnstart.Text = "开始";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // txtprot
            // 
            this.txtprot.Location = new System.Drawing.Point(381, 68);
            this.txtprot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtprot.Name = "txtprot";
            this.txtprot.Size = new System.Drawing.Size(173, 25);
            this.txtprot.TabIndex = 14;
            this.txtprot.Text = "80,90-100";
            this.txtprot.MouseEnter += new System.EventHandler(this.txtprot_MouseEnter);
            this.txtprot.MouseLeave += new System.EventHandler(this.txtprot_MouseLeave);
            // 
            // txtxiancheng
            // 
            this.txtxiancheng.Location = new System.Drawing.Point(381, 28);
            this.txtxiancheng.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtxiancheng.Name = "txtxiancheng";
            this.txtxiancheng.Size = new System.Drawing.Size(173, 25);
            this.txtxiancheng.TabIndex = 13;
            this.txtxiancheng.Text = "500";
            // 
            // labport
            // 
            this.labport.AutoSize = true;
            this.labport.Location = new System.Drawing.Point(295, 71);
            this.labport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labport.Name = "labport";
            this.labport.Size = new System.Drawing.Size(77, 15);
            this.labport.TabIndex = 19;
            this.labport.Text = "端    口:";
            // 
            // labmax
            // 
            this.labmax.AutoSize = true;
            this.labmax.Location = new System.Drawing.Point(295, 31);
            this.labmax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labmax.Name = "labmax";
            this.labmax.Size = new System.Drawing.Size(75, 15);
            this.labmax.TabIndex = 18;
            this.labmax.Text = "最大线程:";
            // 
            // txtendip
            // 
            this.txtendip.Location = new System.Drawing.Point(79, 68);
            this.txtendip.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtendip.Name = "txtendip";
            this.txtendip.Size = new System.Drawing.Size(168, 25);
            this.txtendip.TabIndex = 12;
            // 
            // txtstartip
            // 
            this.txtstartip.Location = new System.Drawing.Point(79, 28);
            this.txtstartip.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtstartip.Name = "txtstartip";
            this.txtstartip.Size = new System.Drawing.Size(168, 25);
            this.txtstartip.TabIndex = 11;
            // 
            // labendip
            // 
            this.labendip.AutoSize = true;
            this.labendip.Location = new System.Drawing.Point(8, 71);
            this.labendip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labendip.Name = "labendip";
            this.labendip.Size = new System.Drawing.Size(61, 15);
            this.labendip.TabIndex = 17;
            this.labendip.Text = "结束IP:";
            // 
            // labstartip
            // 
            this.labstartip.AutoSize = true;
            this.labstartip.Location = new System.Drawing.Point(8, 31);
            this.labstartip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labstartip.Name = "labstartip";
            this.labstartip.Size = new System.Drawing.Size(61, 15);
            this.labstartip.TabIndex = 16;
            this.labstartip.Text = "开始IP:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtresult);
            this.groupBox2.Location = new System.Drawing.Point(16, 134);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(648, 301);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "日志";
            // 
            // txtresult
            // 
            this.txtresult.Location = new System.Drawing.Point(8, 25);
            this.txtresult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtresult.Multiline = true;
            this.txtresult.Name = "txtresult";
            this.txtresult.ReadOnly = true;
            this.txtresult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtresult.Size = new System.Drawing.Size(631, 268);
            this.txtresult.TabIndex = 0;
            // 
            // progressip
            // 
            this.progressip.Location = new System.Drawing.Point(16, 444);
            this.progressip.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressip.Name = "progressip";
            this.progressip.Size = new System.Drawing.Size(648, 29);
            this.progressip.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 480);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(680, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(91, 20);
            this.toolStripStatusLabel1.Text = "Ivy Phoenix";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(125, 20);
            this.toolStripStatusLabel3.Text = "github.com @PhoenixSama";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(0, 20);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 506);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.progressip);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "端口扫描器 v3.0";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnstart;
		private System.Windows.Forms.TextBox txtprot;
		private System.Windows.Forms.TextBox txtxiancheng;
		private System.Windows.Forms.Label labport;
		private System.Windows.Forms.Label labmax;
		private System.Windows.Forms.TextBox txtendip;
		private System.Windows.Forms.TextBox txtstartip;
		private System.Windows.Forms.Label labendip;
		private System.Windows.Forms.Label labstartip;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtresult;
		private System.Windows.Forms.ProgressBar progressip;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
	}
}

