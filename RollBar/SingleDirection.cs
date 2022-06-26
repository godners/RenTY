using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace RollBar
{
    /// <summary>
    /// Single direction rolling bar.
    /// </summary>
    public partial class SingleDirection : UserControl
    {
        #region Region: Parameter & Variable.
        /// <summary>
        /// Running Direction
        /// </summary>
        public DirectionType Direction { 
            get { return _Direction; } 
            set { if (Runner.Enabled) 
                { Runner.Enabled = false; _Direction = value; InitBar(); Runner.Enabled = true; }
                  else _Direction = value; } }
        /// <summary>
        /// Roll Direction
        /// </summary>
        public enum DirectionType {
            /// <summary>
            /// Left To Right
            /// </summary>
            LeftToRight = 0,
            /// <summary>
            /// Right To Left
            /// </summary>
            RightToLeft = 1 }
        private DirectionType _Direction = DirectionType.LeftToRight;
        ///// <summary>
        ///// Running period (second).
        ///// </summary>
        //public double Interval { get { return Runner.Interval / 25; } set{ Runner.Interval = 25 * Value; } }
        /// <summary>
        /// The maximum value is same as width.
        /// </summary>
        public Int32 Maximum { get { return Width; } }
        /// <summary>
        /// The minimum value is 0.
        /// </summary>
        public Int32 Minimum { get { return 0; } }
        /// <summary>
        /// Get value for status now.
        /// </summary>
        public Int32 Value = 0;
        #endregion

        /// <summary>
        /// Single direction rolling bar.
        /// </summary>
        #region Region: Inherit the parameter changed.
        public SingleDirection() => InitializeComponent();
        private void SingleDirection_SizeChanged(object sender, EventArgs e) { Bar.Size = Size; }
        private void SingleDirection_Resize(object sender, EventArgs e) { Bar.Size = Size; }
        private void SingleDirection_BackColorChanged(object sender, EventArgs e) => Bar.BackColor = BackColor;
        private void SingleDirection_CursorChanged(object sender, EventArgs e) => Bar.Cursor = Cursor;
        private void SingleDirection_ForeColorChanged(object sender, EventArgs e) => Bar.ForeColor = ForeColor;
        private void SingleDirection_VisibleChanged(object sender, EventArgs e) => Bar.Visible = Visible;
        private void SingleDirection_EnabledChanged(object sender, EventArgs e)
        { if (!Runner.Enabled) { InitBar(); Runner.Enabled = true; } else Runner.Enabled = false; }
        //↑↑↑↑有错误
        #endregion

        private void InitBar()
        {
            //Bar.Value = Direction == DirectionType.LeftToRight ? 100 : 0;
            Bar.Maximum = Direction == DirectionType.LeftToRight ? 100 : 100;
            Bar.Minimum = Direction == DirectionType.LeftToRight ? 0 : 0;
            Bar.Value = 0;
            Bar.Location = new Point(0, 0); 
        }
        private void FlushBar()
        {
            //↓↓↓逻辑不对，重点关注初始值
            if (Bar.Value % 100 == 0) ReverseBar();
            Int32 i = Bar.RightToLeft == RightToLeft.No ? 5 : -5;
            i = Direction == DirectionType.LeftToRight ? i: 0 - i;
            Debug.WriteLine($"{Bar.RightToLeft},{Direction},{i},{Bar.Value}");
            Bar.Value += i;
            


            //Int32 delta = Bar.RightToLeft == RightToLeft.No ? 5 : -5;
            //Debug.WriteLine($"{Bar.RightToLeft}:{delta}--");
            //delta = Direction == DirectionType.LeftToRight ? delta : 0 - delta;
            //Debug.WriteLine($"{Direction}:{delta}--{Bar.Value}");
            //Bar.Value += delta;





        }

        private void ReverseBar()
        {
            Bar.RightToLeft = Bar.RightToLeft ==
            RightToLeft.Yes ? RightToLeft.No : RightToLeft.Yes;
        }

        private void Runner_Tick(object sender, EventArgs e) => FlushBar();
    }
}
