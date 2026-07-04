namespace AdvancedChatLab.Desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnSendPublic = new MaterialSkin.Controls.MaterialButton();
            btnSendPrivate = new MaterialSkin.Controls.MaterialButton();
            btnJoinRoom = new MaterialSkin.Controls.MaterialButton();
            btnCreateRoom = new MaterialSkin.Controls.MaterialButton();
            txtMessage = new MaterialSkin.Controls.MaterialTextBox();
            cmbUsers = new MaterialSkin.Controls.MaterialComboBox();
            cmbRooms = new MaterialSkin.Controls.MaterialComboBox();
            txtNewRoomName = new MaterialSkin.Controls.MaterialTextBox();
            rtbChatBoard = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(30, 78);
            label1.Name = "label1";
            label1.Size = new Size(191, 20);
            label1.TabIndex = 6;
            label1.Text = "Messages and Notifications";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(416, 120);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 8;
            label3.Text = "User Message";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(416, 287);
            label4.Name = "label4";
            label4.Size = new Size(93, 20);
            label4.TabIndex = 10;
            label4.Text = "Select Room";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F);
            label5.Location = new Point(416, 202);
            label5.Name = "label5";
            label5.Size = new Size(164, 20);
            label5.TabIndex = 12;
            label5.Text = "Select User to chat with";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F);
            label6.Location = new Point(416, 384);
            label6.Name = "label6";
            label6.Size = new Size(96, 20);
            label6.TabIndex = 16;
            label6.Text = "Create Room";
            // 
            // btnSendPublic
            // 
            btnSendPublic.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSendPublic.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSendPublic.Depth = 0;
            btnSendPublic.HighEmphasis = true;
            btnSendPublic.Icon = null;
            btnSendPublic.Location = new Point(673, 141);
            btnSendPublic.Margin = new Padding(4, 6, 4, 6);
            btnSendPublic.MouseState = MaterialSkin.MouseState.HOVER;
            btnSendPublic.Name = "btnSendPublic";
            btnSendPublic.NoAccentTextColor = Color.Empty;
            btnSendPublic.Size = new Size(113, 36);
            btnSendPublic.TabIndex = 17;
            btnSendPublic.Text = "Send Public";
            btnSendPublic.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSendPublic.UseAccentColor = false;
            btnSendPublic.UseVisualStyleBackColor = true;
            // 
            // btnSendPrivate
            // 
            btnSendPrivate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSendPrivate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSendPrivate.Depth = 0;
            btnSendPrivate.HighEmphasis = true;
            btnSendPrivate.Icon = null;
            btnSendPrivate.Location = new Point(673, 219);
            btnSendPrivate.Margin = new Padding(4, 6, 4, 6);
            btnSendPrivate.MouseState = MaterialSkin.MouseState.HOVER;
            btnSendPrivate.Name = "btnSendPrivate";
            btnSendPrivate.NoAccentTextColor = Color.Empty;
            btnSendPrivate.Size = new Size(122, 36);
            btnSendPrivate.TabIndex = 18;
            btnSendPrivate.Text = "Send Private";
            btnSendPrivate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSendPrivate.UseAccentColor = false;
            btnSendPrivate.UseVisualStyleBackColor = true;
            // 
            // btnJoinRoom
            // 
            btnJoinRoom.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnJoinRoom.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnJoinRoom.Depth = 0;
            btnJoinRoom.HighEmphasis = true;
            btnJoinRoom.Icon = null;
            btnJoinRoom.Location = new Point(673, 302);
            btnJoinRoom.Margin = new Padding(4, 6, 4, 6);
            btnJoinRoom.MouseState = MaterialSkin.MouseState.HOVER;
            btnJoinRoom.Name = "btnJoinRoom";
            btnJoinRoom.NoAccentTextColor = Color.Empty;
            btnJoinRoom.Size = new Size(100, 36);
            btnJoinRoom.TabIndex = 19;
            btnJoinRoom.Text = "Join Room";
            btnJoinRoom.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnJoinRoom.UseAccentColor = false;
            btnJoinRoom.UseVisualStyleBackColor = true;
            // 
            // btnCreateRoom
            // 
            btnCreateRoom.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCreateRoom.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCreateRoom.Depth = 0;
            btnCreateRoom.HighEmphasis = true;
            btnCreateRoom.Icon = null;
            btnCreateRoom.Location = new Point(673, 401);
            btnCreateRoom.Margin = new Padding(4, 6, 4, 6);
            btnCreateRoom.MouseState = MaterialSkin.MouseState.HOVER;
            btnCreateRoom.Name = "btnCreateRoom";
            btnCreateRoom.NoAccentTextColor = Color.Empty;
            btnCreateRoom.Size = new Size(157, 36);
            btnCreateRoom.TabIndex = 21;
            btnCreateRoom.Text = "Create New Room";
            btnCreateRoom.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCreateRoom.UseAccentColor = false;
            btnCreateRoom.UseVisualStyleBackColor = true;
            // 
            // txtMessage
            // 
            txtMessage.AnimateReadOnly = false;
            txtMessage.BorderStyle = BorderStyle.None;
            txtMessage.Depth = 0;
            txtMessage.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMessage.LeadingIcon = null;
            txtMessage.Location = new Point(416, 145);
            txtMessage.MaxLength = 50;
            txtMessage.MouseState = MaterialSkin.MouseState.OUT;
            txtMessage.Multiline = false;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(210, 50);
            txtMessage.TabIndex = 22;
            txtMessage.Text = "";
            txtMessage.TrailingIcon = null;
            // 
            // cmbUsers
            // 
            cmbUsers.AutoResize = false;
            cmbUsers.BackColor = Color.FromArgb(255, 255, 255);
            cmbUsers.Depth = 0;
            cmbUsers.DrawMode = DrawMode.OwnerDrawVariable;
            cmbUsers.DropDownHeight = 174;
            cmbUsers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsers.DropDownWidth = 121;
            cmbUsers.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbUsers.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbUsers.FormattingEnabled = true;
            cmbUsers.IntegralHeight = false;
            cmbUsers.ItemHeight = 43;
            cmbUsers.Location = new Point(416, 225);
            cmbUsers.MaxDropDownItems = 4;
            cmbUsers.MouseState = MaterialSkin.MouseState.OUT;
            cmbUsers.Name = "cmbUsers";
            cmbUsers.Size = new Size(210, 49);
            cmbUsers.StartIndex = 0;
            cmbUsers.TabIndex = 23;
            // 
            // cmbRooms
            // 
            cmbRooms.AutoResize = false;
            cmbRooms.BackColor = Color.FromArgb(255, 255, 255);
            cmbRooms.Depth = 0;
            cmbRooms.DrawMode = DrawMode.OwnerDrawVariable;
            cmbRooms.DropDownHeight = 174;
            cmbRooms.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRooms.DropDownWidth = 121;
            cmbRooms.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbRooms.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbRooms.FormattingEnabled = true;
            cmbRooms.IntegralHeight = false;
            cmbRooms.ItemHeight = 43;
            cmbRooms.Location = new Point(416, 308);
            cmbRooms.MaxDropDownItems = 4;
            cmbRooms.MouseState = MaterialSkin.MouseState.OUT;
            cmbRooms.Name = "cmbRooms";
            cmbRooms.Size = new Size(210, 49);
            cmbRooms.StartIndex = 0;
            cmbRooms.TabIndex = 24;
            // 
            // txtNewRoomName
            // 
            txtNewRoomName.AnimateReadOnly = false;
            txtNewRoomName.BorderStyle = BorderStyle.None;
            txtNewRoomName.Depth = 0;
            txtNewRoomName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNewRoomName.LeadingIcon = null;
            txtNewRoomName.Location = new Point(416, 407);
            txtNewRoomName.MaxLength = 50;
            txtNewRoomName.MouseState = MaterialSkin.MouseState.OUT;
            txtNewRoomName.Multiline = false;
            txtNewRoomName.Name = "txtNewRoomName";
            txtNewRoomName.Size = new Size(210, 50);
            txtNewRoomName.TabIndex = 26;
            txtNewRoomName.Text = "";
            txtNewRoomName.TrailingIcon = null;
            // 
            // rtbChatBoard
            // 
            rtbChatBoard.BackColor = Color.FromArgb(255, 255, 255);
            rtbChatBoard.BorderStyle = BorderStyle.None;
            rtbChatBoard.Depth = 0;
            rtbChatBoard.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            rtbChatBoard.ForeColor = Color.FromArgb(222, 0, 0, 0);
            rtbChatBoard.Location = new Point(30, 105);
            rtbChatBoard.MouseState = MaterialSkin.MouseState.HOVER;
            rtbChatBoard.Name = "rtbChatBoard";
            rtbChatBoard.Size = new Size(314, 370);
            rtbChatBoard.TabIndex = 27;
            rtbChatBoard.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(872, 493);
            Controls.Add(rtbChatBoard);
            Controls.Add(txtNewRoomName);
            Controls.Add(cmbRooms);
            Controls.Add(cmbUsers);
            Controls.Add(txtMessage);
            Controls.Add(btnCreateRoom);
            Controls.Add(btnJoinRoom);
            Controls.Add(btnSendPrivate);
            Controls.Add(btnSendPublic);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Halemo Chat";
            Load += Form1_LoadAsync;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private MaterialSkin.Controls.MaterialButton btnSendPublic;
        private MaterialSkin.Controls.MaterialButton btnSendPrivate;
        private MaterialSkin.Controls.MaterialButton btnJoinRoom;
        private MaterialSkin.Controls.MaterialButton btnCreateRoom;
        private MaterialSkin.Controls.MaterialTextBox txtMessage;
        private MaterialSkin.Controls.MaterialComboBox cmbUsers;
        private MaterialSkin.Controls.MaterialComboBox cmbRooms;
        private MaterialSkin.Controls.MaterialTextBox txtNewRoomName;
        private MaterialSkin.Controls.MaterialMultiLineTextBox rtbChatBoard;
    }
}
