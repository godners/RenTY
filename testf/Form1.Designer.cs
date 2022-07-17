namespace testf
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.controlBar1 = new RenTY.ControlBar();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(226, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // controlBar1
            // 
            this.controlBar1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.controlBar1.Enabled = false;
            this.controlBar1.FlushPeriod = 100;
            this.controlBar1.Location = new System.Drawing.Point(118, 97);
            this.controlBar1.Name = "controlBar1";
            this.controlBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.controlBar1.RollMode = RenTY.EnumRollBarMode.SingleDirection;
            this.controlBar1.RollPeriod = 3000;
            this.controlBar1.Size = new System.Drawing.Size(100, 16);
            this.controlBar1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.controlBar1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private RenTY.ControlBar controlBar1;
    }
}

