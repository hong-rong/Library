namespace CSharp.WinFormMVC.Event.View
{
    partial class IncreaseView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._buttonIncrease = new System.Windows.Forms.Button();
            this._textBoxIncreasedValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _buttonIncrease
            // 
            this._buttonIncrease.Location = new System.Drawing.Point(174, 34);
            this._buttonIncrease.Name = "_buttonIncrease";
            this._buttonIncrease.Size = new System.Drawing.Size(75, 23);
            this._buttonIncrease.TabIndex = 0;
            this._buttonIncrease.Text = "Increase";
            this._buttonIncrease.UseVisualStyleBackColor = true;
            this._buttonIncrease.Click += new System.EventHandler(this._buttonIncrease_Click);
            // 
            // _textBoxIncreasedValue
            // 
            this._textBoxIncreasedValue.Location = new System.Drawing.Point(53, 34);
            this._textBoxIncreasedValue.Name = "_textBoxIncreasedValue";
            this._textBoxIncreasedValue.Size = new System.Drawing.Size(100, 20);
            this._textBoxIncreasedValue.TabIndex = 1;
            this._textBoxIncreasedValue.TextChanged += new System.EventHandler(this._textBoxIncreasedValue_TextChanged);
            // 
            // IncreaseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 88);
            this.Controls.Add(this._textBoxIncreasedValue);
            this.Controls.Add(this._buttonIncrease);
            this.Name = "IncreaseView";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _buttonIncrease;
        private System.Windows.Forms.TextBox _textBoxIncreasedValue;
    }
}

