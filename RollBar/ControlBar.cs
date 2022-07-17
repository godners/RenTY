using System;
using System.Windows.Forms;

namespace RenTY
{
    /// <summary>
    /// 滚动进度条
    /// </summary>
    public partial class ControlBar : UserControl
    {
        #region Region 运行变量
        #region Sub-Region 滚动模式
        private EnumRollBarMode _RollMode = EnumRollBarMode.SingleDirection;
        /// <summary>
        /// 滚动模式
        /// </summary>
        public EnumRollBarMode RollMode
        {
            get { return _RollMode; }
            set { _RollMode = value; if (Enabled) { Enabled = false; Enabled = true; } }
        }
        #endregion
        #region Sub-Region 刷新频率（毫秒/次）
        private Int32 _FlushPeriod = 100;
        /// <summary>
        /// 刷新频率（毫秒/次）
        /// </summary>
        public Int32 FlushPeriod
        {
            get { return _FlushPeriod; }
            set { _FlushPeriod = value; TimerMain.Interval = value; }
        }
        #endregion
        #region Sub-Region 滚动周期（毫秒/圈）
        private Int32 _RollPeriod = 3000;
        /// <summary>
        /// 滚动周期（毫秒/圈）
        /// </summary>
        public Int32 RollPeriod
        {
            get { return _RollPeriod; }
            set { _RollPeriod = value; }
        }
        #endregion
        #region Sub-Region 滚动状态
        private EnumDirection DirectionState = EnumDirection.LeftToRight_Raise;
        private enum EnumDirection
        { LeftToRight_Raise = 0, LeftToRight_Reduce = 1, RightToLeft_Raise = 2, RightToLeft_Reduce = 3 }
        //↑↑↑左右方向，绿色加减（Raise，Reduce）
        #endregion
        /// <summary>
        /// 已初始化
        /// </summary>
        private Boolean Initialized = false;
        #endregion
        #region Region 构建与初始化
        /// <summary>
        /// 构建控件
        /// </summary>
        public ControlBar() => InitializeComponent();
        /// <summary>
        /// 加载控件
        /// </summary>
        private void ControlBar_Load(object sender, EventArgs e)
        { Initialize(); ParamFollow(sender, e); }
        /// <summary>
        /// 属性跟随
        /// </summary>
        private void ParamFollow(object sender, EventArgs e)
        {
            BarMain.Size = ((UserControl)sender).Size;
            BarMain.ForeColor = ((UserControl)sender).ForeColor;
            BarMain.BackColor = ((UserControl)sender).BackColor;
            BarMain.Cursor = ((UserControl)sender).Cursor;
        }
        /// <summary>
        /// 属性锁定
        /// </summary>
        private void ParamLock(object sender, EventArgs e)
        {
            AutoSize = false;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackgroundImage = null;
            BackgroundImageLayout = ImageLayout.Tile;
            CausesValidation = true;
            Padding = new Padding(0);
            RightToLeft = RightToLeft.Yes;
        }
        #endregion
        #region Region 指令跟随
        private void ControlBar_EnabledChanged(object sender, EventArgs e)
        { if (!Initialized) Initialize(); else Initialized = false; TimerMain.Enabled = Enabled; }
        private void Initialize()
        {
            BarMain.Value = 0; Initialized = true;
            DirectionState = EnumDirection.LeftToRight_Raise;
            BarMain.RightToLeft = RightToLeft.No;
        }
        #endregion
        #region Region 运行过程
        /// <summary>
        /// 时钟响应
        /// </summary>
        private void TimerMain_Tick(object sender, EventArgs e)
        { if (!Initialized) Initialize(); if (Terminated()) SwitchState(); BarMain.Value += StepLength(); }
        #region Sub-Region 状态切换
        /// <summary>
        /// 状态切换
        /// </summary>
        private void SwitchState()
        {
            switch (RollMode)
            {
                case EnumRollBarMode.SingleDirection: SwitchStateSingle(); break;
                case EnumRollBarMode.DoubleDirection: SwitchStateDouble(); break;
                default: break;
            }
        }
        /// <summary>
        /// 状态切换（单向）
        /// </summary>
        private void SwitchStateSingle()
        {
            switch (DirectionState)
            {
                case EnumDirection.LeftToRight_Raise:
                    DirectionState = EnumDirection.LeftToRight_Reduce;
                    BarMain.RightToLeft = RightToLeft.Yes; break;
                case EnumDirection.LeftToRight_Reduce:
                    DirectionState = EnumDirection.LeftToRight_Raise;
                    BarMain.RightToLeft = RightToLeft.No; break;
                default: break;
            }
        }
        /// <summary>
        /// 状态切换（双向）
        /// </summary>
        private void SwitchStateDouble()
        {
            switch (DirectionState)
            {
                case EnumDirection.LeftToRight_Raise:
                    DirectionState = EnumDirection.LeftToRight_Reduce;
                    BarMain.RightToLeft = RightToLeft.Yes; break;
                case EnumDirection.LeftToRight_Reduce:
                    DirectionState = EnumDirection.RightToLeft_Raise;
                    BarMain.RightToLeft = RightToLeft.Yes; break;
                case EnumDirection.RightToLeft_Raise:
                    DirectionState = EnumDirection.RightToLeft_Reduce;
                    BarMain.RightToLeft = RightToLeft.No; break;
                case EnumDirection.RightToLeft_Reduce:
                    DirectionState = EnumDirection.LeftToRight_Raise;
                    BarMain.RightToLeft = RightToLeft.No; break;
                default: break;
            }
        }
        #endregion
        /// <summary>
        /// 判断到达端点
        /// </summary>
        private Boolean Terminated()
        {
            switch (DirectionState)
            {
                case EnumDirection.LeftToRight_Raise:
                case EnumDirection.RightToLeft_Raise:
                    return BarMain.Value + StepLength() > BarMain.Maximum;
                case EnumDirection.LeftToRight_Reduce:
                case EnumDirection.RightToLeft_Reduce:
                    return BarMain.Value + StepLength() < BarMain.Minimum;
                default: return false;
            }
        }
        #region Sub-Region 计算步长
        /// <summary>
        /// 单次步长
        /// </summary>
        private Int32 StepLength() =>
            BarMain.Maximum / RollPeriod * FlushPeriod * 2 * DirectionSymbol();
        /// <summary>
        /// 方向符号
        /// </summary>
        private Int32 DirectionSymbol()
        {
            switch (DirectionState)
            {
                case EnumDirection.LeftToRight_Raise: return 1;
                case EnumDirection.LeftToRight_Reduce: return -1;
                case EnumDirection.RightToLeft_Raise: return 1;
                case EnumDirection.RightToLeft_Reduce: return -1;
                default: return 0;
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// 滚动模式
    /// </summary>
    public enum EnumRollBarMode
    {
        /// <summary>
        /// 单向滚动
        /// </summary>
        SingleDirection = 0,
        /// <summary>
        /// 双向滚动
        /// </summary>
        DoubleDirection = 1
    }
}
