namespace DeskNoManager
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
            this.lblNo1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblFree = new System.Windows.Forms.Label();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNo1
            // 
            this.lblNo1.AutoSize = true;
            this.lblNo1.BackColor = System.Drawing.Color.Transparent;
            this.lblNo1.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNo1.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblNo1.Location = new System.Drawing.Point(505, 665);
            this.lblNo1.Name = "lblNo1";
            this.lblNo1.Size = new System.Drawing.Size(137, 75);
            this.lblNo1.TabIndex = 0;
            this.lblNo1.Text = "000";
            this.lblNo1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.LightCoral;
            this.label1.Location = new System.Drawing.Point(220, 741);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "提示：按回车键开始，按空格键停止。";
            // 
            // lblFree
            // 
            this.lblFree.AutoSize = true;
            this.lblFree.Location = new System.Drawing.Point(775, 741);
            this.lblFree.Name = "lblFree";
            this.lblFree.Size = new System.Drawing.Size(71, 12);
            this.lblFree.TabIndex = 2;
            this.lblFree.Text = "剩余0个号码";
            this.lblFree.Visible = false;
            // 
            // pic1
            // 
            this.pic1.BackColor = System.Drawing.Color.Transparent;
            this.pic1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pic1.Image = global::DeskNoManager.Properties.Resources._0;
            this.pic1.Location = new System.Drawing.Point(66, 184);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(295, 396);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic1.TabIndex = 3;
            this.pic1.TabStop = false;
            // 
            // pic2
            // 
            this.pic2.BackColor = System.Drawing.Color.Transparent;
            this.pic2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pic2.Image = ((System.Drawing.Image)(resources.GetObject("pic2.Image")));
            this.pic2.Location = new System.Drawing.Point(359, 186);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(295, 396);
            this.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic2.TabIndex = 4;
            this.pic2.TabStop = false;
            // 
            // pic3
            // 
            this.pic3.BackColor = System.Drawing.Color.Transparent;
            this.pic3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pic3.Image = ((System.Drawing.Image)(resources.GetObject("pic3.Image")));
            this.pic3.Location = new System.Drawing.Point(659, 186);
            this.pic3.Name = "pic3";
            this.pic3.Size = new System.Drawing.Size(295, 396);
            this.pic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic3.TabIndex = 5;
            this.pic3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DeskNoManager.Properties.Resources.取号7;
            this.ClientSize = new System.Drawing.Size(1023, 762);
            this.Controls.Add(this.pic3);
            this.Controls.Add(this.pic2);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.lblFree);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNo1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "上海易溯科技欢迎您";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNo1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFree;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.PictureBox pic3;
    }
}

