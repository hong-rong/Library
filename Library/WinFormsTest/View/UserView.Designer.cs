namespace WinFormsTest
{
    partial class UserForm
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
            this.label1 = new System.Windows.Forms.Label();
            this._textBoxFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._textBoxLastName = new System.Windows.Forms.TextBox();
            this._textBoxId = new System.Windows.Forms.TextBox();
            this._textBoxDepartment = new System.Windows.Forms.TextBox();
            this._buttonAddUser = new System.Windows.Forms.Button();
            this._buttonRemoveUser = new System.Windows.Forms.Button();
            this._buttonRegisterUser = new System.Windows.Forms.Button();
            this._listViewUser = new System.Windows.Forms.ListView();
            this._radioButtonMale = new System.Windows.Forms.RadioButton();
            this._radioButtonFemale = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name:";
            // 
            // _textBoxFirstName
            // 
            this._textBoxFirstName.Location = new System.Drawing.Point(113, 26);
            this._textBoxFirstName.Name = "_textBoxFirstName";
            this._textBoxFirstName.Size = new System.Drawing.Size(117, 20);
            this._textBoxFirstName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Department:";
            // 
            // _textBoxLastName
            // 
            this._textBoxLastName.Location = new System.Drawing.Point(113, 73);
            this._textBoxLastName.Name = "_textBoxLastName";
            this._textBoxLastName.Size = new System.Drawing.Size(117, 20);
            this._textBoxLastName.TabIndex = 5;
            // 
            // _textBoxId
            // 
            this._textBoxId.Location = new System.Drawing.Point(359, 30);
            this._textBoxId.Name = "_textBoxId";
            this._textBoxId.Size = new System.Drawing.Size(117, 20);
            this._textBoxId.TabIndex = 6;
            // 
            // _textBoxDepartment
            // 
            this._textBoxDepartment.Location = new System.Drawing.Point(359, 69);
            this._textBoxDepartment.Name = "_textBoxDepartment";
            this._textBoxDepartment.Size = new System.Drawing.Size(117, 20);
            this._textBoxDepartment.TabIndex = 7;
            // 
            // _buttonAddUser
            // 
            this._buttonAddUser.Location = new System.Drawing.Point(555, 24);
            this._buttonAddUser.Name = "_buttonAddUser";
            this._buttonAddUser.Size = new System.Drawing.Size(102, 23);
            this._buttonAddUser.TabIndex = 8;
            this._buttonAddUser.Text = "Add New User";
            this._buttonAddUser.UseVisualStyleBackColor = true;
            this._buttonAddUser.Click += new System.EventHandler(this._buttonAddUser_Click);
            // 
            // _buttonRemoveUser
            // 
            this._buttonRemoveUser.Location = new System.Drawing.Point(555, 66);
            this._buttonRemoveUser.Name = "_buttonRemoveUser";
            this._buttonRemoveUser.Size = new System.Drawing.Size(102, 23);
            this._buttonRemoveUser.TabIndex = 9;
            this._buttonRemoveUser.Text = "Remove User";
            this._buttonRemoveUser.UseVisualStyleBackColor = true;
            this._buttonRemoveUser.Click += new System.EventHandler(this._buttonRemoveUser_Click);
            // 
            // _buttonRegisterUser
            // 
            this._buttonRegisterUser.Location = new System.Drawing.Point(555, 128);
            this._buttonRegisterUser.Name = "_buttonRegisterUser";
            this._buttonRegisterUser.Size = new System.Drawing.Size(102, 23);
            this._buttonRegisterUser.TabIndex = 10;
            this._buttonRegisterUser.Text = "Register User";
            this._buttonRegisterUser.UseVisualStyleBackColor = true;
            this._buttonRegisterUser.Click += new System.EventHandler(this._buttonRegisterUser_Click);
            // 
            // _listViewUser
            // 
            this._listViewUser.Location = new System.Drawing.Point(12, 170);
            this._listViewUser.Name = "_listViewUser";
            this._listViewUser.Size = new System.Drawing.Size(686, 303);
            this._listViewUser.TabIndex = 11;
            this._listViewUser.UseCompatibleStateImageBehavior = false;
            this._listViewUser.View = System.Windows.Forms.View.Details;
            // 
            // _radioButtonMale
            // 
            this._radioButtonMale.AutoSize = true;
            this._radioButtonMale.Location = new System.Drawing.Point(84, 128);
            this._radioButtonMale.Name = "_radioButtonMale";
            this._radioButtonMale.Size = new System.Drawing.Size(48, 17);
            this._radioButtonMale.TabIndex = 12;
            this._radioButtonMale.TabStop = true;
            this._radioButtonMale.Text = "Maie";
            this._radioButtonMale.UseVisualStyleBackColor = true;
            // 
            // _radioButtonFemale
            // 
            this._radioButtonFemale.AutoSize = true;
            this._radioButtonFemale.Location = new System.Drawing.Point(194, 128);
            this._radioButtonFemale.Name = "_radioButtonFemale";
            this._radioButtonFemale.Size = new System.Drawing.Size(59, 17);
            this._radioButtonFemale.TabIndex = 13;
            this._radioButtonFemale.TabStop = true;
            this._radioButtonFemale.Text = "Female";
            this._radioButtonFemale.UseVisualStyleBackColor = true;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 485);
            this.Controls.Add(this._radioButtonFemale);
            this.Controls.Add(this._radioButtonMale);
            this.Controls.Add(this._listViewUser);
            this.Controls.Add(this._buttonRegisterUser);
            this.Controls.Add(this._buttonRemoveUser);
            this.Controls.Add(this._buttonAddUser);
            this.Controls.Add(this._textBoxDepartment);
            this.Controls.Add(this._textBoxId);
            this.Controls.Add(this._textBoxLastName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._textBoxFirstName);
            this.Controls.Add(this.label1);
            this.Name = "UserForm";
            this.Text = "UserDisplay";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _textBoxFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _textBoxLastName;
        private System.Windows.Forms.TextBox _textBoxId;
        private System.Windows.Forms.TextBox _textBoxDepartment;
        private System.Windows.Forms.Button _buttonAddUser;
        private System.Windows.Forms.Button _buttonRemoveUser;
        private System.Windows.Forms.Button _buttonRegisterUser;
        private System.Windows.Forms.ListView _listViewUser;
        private System.Windows.Forms.RadioButton _radioButtonMale;
        private System.Windows.Forms.RadioButton _radioButtonFemale;
    }
}

