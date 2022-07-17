namespace RollBar
{
    partial class SingleDirection
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Bar = new System.Windows.Forms.ProgressBar();
            this.Runner = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Bar
            // 
            this.Bar.Location = new System.Drawing.Point(0, 0);
            this.Bar.Margin = new System.Windows.Forms.Padding(0);
            this.Bar.Name = "Bar";
            this.Bar.RightToLeftLayout = true;
            this.Bar.Size = new System.Drawing.Size(128, 16);
            this.Bar.TabIndex = 0;
            // 
            // Runner
            // 
            this.Runner.Tick += new System.EventHandler(this.Runner_Tick);
            // 
            // SingleDirection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Bar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SingleDirection";
            this.Size = new System.Drawing.Size(128, 16);
            this.BackColorChanged += new System.EventHandler(this.SingleDirection_BackColorChanged);
            this.CursorChanged += new System.EventHandler(this.SingleDirection_CursorChanged);
            this.EnabledChanged += new System.EventHandler(this.SingleDirection_EnabledChanged);
            this.ForeColorChanged += new System.EventHandler(this.SingleDirection_ForeColorChanged);
            this.SizeChanged += new System.EventHandler(this.SingleDirection_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.SingleDirection_VisibleChanged);
            this.Resize += new System.EventHandler(this.SingleDirection_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar Bar;
        private System.Windows.Forms.Timer Runner;
    }
}
