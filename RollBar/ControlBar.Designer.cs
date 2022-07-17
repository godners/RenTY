namespace RenTY
{
    partial class ControlBar
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
            if (disposing && (components != null)) components.Dispose();
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
            this.BarMain = new System.Windows.Forms.ProgressBar();
            this.TimerMain = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // BarMain
            // 
            this.BarMain.Location = new System.Drawing.Point(0, 0);
            this.BarMain.Margin = new System.Windows.Forms.Padding(0);
            this.BarMain.Maximum = 10000;
            this.BarMain.Name = "BarMain";
            this.BarMain.RightToLeftLayout = true;
            this.BarMain.Size = new System.Drawing.Size(100, 16);
            this.BarMain.TabIndex = 0;
            // 
            // TimerMain
            // 
            this.TimerMain.Tick += new System.EventHandler(this.TimerMain_Tick);
            // 
            // ControlBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Controls.Add(this.BarMain);
            this.Enabled = false;
            this.Name = "ControlBar";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(100, 16);
            this.Padding = new System.Windows.Forms.Padding(0);
            this.AutoSizeChanged += new System.EventHandler(this.ParamLock);
            this.AutoValidateChanged += new System.EventHandler(this.ParamLock);
            this.Load += new System.EventHandler(this.ControlBar_Load);
            this.BackColorChanged += new System.EventHandler(this.ParamFollow);
            this.BackgroundImageChanged += new System.EventHandler(this.ParamLock);
            this.BackgroundImageLayoutChanged += new System.EventHandler(this.ParamLock);
            this.CausesValidationChanged += new System.EventHandler(this.ParamLock);
            this.CursorChanged += new System.EventHandler(this.ParamFollow);
            this.EnabledChanged += new System.EventHandler(this.ControlBar_EnabledChanged);
            this.ForeColorChanged += new System.EventHandler(this.ParamFollow);
            this.RightToLeftChanged += new System.EventHandler(this.ParamLock);
            this.SizeChanged += new System.EventHandler(this.ParamFollow);
            this.PaddingChanged += new System.EventHandler(this.ParamLock);
            this.Resize += new System.EventHandler(this.ParamFollow);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar BarMain;
        private System.Windows.Forms.Timer TimerMain;
    }
}
