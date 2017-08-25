namespace CSharp.Winform.Async
{
    partial class Form1
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
            this._buttonStart = new System.Windows.Forms.Button();
            this._textBoxResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _buttonStart
            // 
            this._buttonStart.Location = new System.Drawing.Point(187, 165);
            this._buttonStart.Name = "_buttonStart";
            this._buttonStart.Size = new System.Drawing.Size(75, 23);
            this._buttonStart.TabIndex = 0;
            this._buttonStart.Text = "start";
            this._buttonStart.UseVisualStyleBackColor = true;
            this._buttonStart.Click += new System.EventHandler(this._buttonStart_Click);
            // 
            // _textBoxResult
            // 
            this._textBoxResult.Location = new System.Drawing.Point(12, 12);
            this._textBoxResult.Multiline = true;
            this._textBoxResult.Name = "_textBoxResult";
            this._textBoxResult.Size = new System.Drawing.Size(250, 147);
            this._textBoxResult.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 194);
            this.Controls.Add(this._textBoxResult);
            this.Controls.Add(this._buttonStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _buttonStart;
        private System.Windows.Forms.TextBox _textBoxResult;
    }
}

