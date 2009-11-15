//-----------------------------------------------------------------------
// <copyright file="AnglesTracker.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Pavel Shkleinik</author>
//-----------------------------------------------------------------------

namespace Modeling.UI.Controls
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Class to render current rotation angles.
    /// </summary>
    public partial class AnglesTracker : UserControl
    {
        #region Contructors
        /// <summary>
        /// Initializes new instance of the <see cref="AnglesTracker"/>.
        /// </summary>
        public AnglesTracker()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Implement this constructor to get rid off three angle properties and automate angles tracking.
        /// Pass following parameters as references.
        /// </summary>
        /// <param name="alpha">Rotation angle around X-axis</param>
        /// <param name="beta">Rotation angle around Y-axis</param>
        /// <param name="gama">Rotation angle around Z-axis</param>
        public AnglesTracker(ref double alpha, ref double beta, ref  double gama)
        {
            throw new Exception();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Rotation angle around X-axis
        /// </summary>
        public string Alpha
        {
            get
            {
                return lblAlphaValue.Text;
            }

            set
            {
                lblAlphaValue.Text = value;
            }
        }

        /// <summary>
        /// Rotation angle around Y-axis
        /// </summary>

        public string Beta
        {
            get
            {
                return lblBetaValue.Text;
            }
            set
            {
                lblBetaValue.Text = value;
            }
        }

        /// <summary>
        /// Rotation angle around Z-axis
        /// </summary>
        public string Gamma
        {
            get
            {
                return lblGammaValue.Text;
            }
            set
            {
                lblGammaValue.Text = value;
            }
        }
        #endregion
    }
}
