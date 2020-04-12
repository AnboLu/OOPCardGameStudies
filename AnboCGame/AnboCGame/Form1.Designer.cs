namespace AnboCGame
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.lblTurn = new System.Windows.Forms.Label();
            this.lblRules = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbEasy = new System.Windows.Forms.RadioButton();
            this.rdbNormal = new System.Windows.Forms.RadioButton();
            this.rdbQuick = new System.Windows.Forms.RadioButton();
            this.rdbDeath = new System.Windows.Forms.RadioButton();
            this.lblHealthAI = new System.Windows.Forms.Label();
            this.lblChangeAI = new System.Windows.Forms.Label();
            this.lblAtkAI = new System.Windows.Forms.Label();
            this.lblDefAI = new System.Windows.Forms.Label();
            this.lblHealthPL = new System.Windows.Forms.Label();
            this.lblChangePL = new System.Windows.Forms.Label();
            this.lblAtkPL = new System.Windows.Forms.Label();
            this.lblDefPL = new System.Windows.Forms.Label();
            this.lblActions = new System.Windows.Forms.Label();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnBattle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Location = new System.Drawing.Point(323, 48);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(710, 178);
            this.Panel1.TabIndex = 0;
            // 
            // Panel2
            // 
            this.Panel2.Location = new System.Drawing.Point(323, 362);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(710, 178);
            this.Panel2.TabIndex = 1;
            // 
            // lblTurn
            // 
            this.lblTurn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTurn.Location = new System.Drawing.Point(323, 258);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(710, 68);
            this.lblTurn.TabIndex = 2;
            this.lblTurn.Text = "lblTurn";
            this.lblTurn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRules
            // 
            this.lblRules.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRules.Location = new System.Drawing.Point(51, 48);
            this.lblRules.Name = "lblRules";
            this.lblRules.Size = new System.Drawing.Size(241, 177);
            this.lblRules.TabIndex = 3;
            this.lblRules.Text = "lblRules";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbNormal);
            this.groupBox1.Controls.Add(this.rdbEasy);
            this.groupBox1.Location = new System.Drawing.Point(51, 259);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 132);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AI Level";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbDeath);
            this.groupBox2.Controls.Add(this.rdbQuick);
            this.groupBox2.Location = new System.Drawing.Point(51, 411);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 129);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Duel Length";
            // 
            // rdbEasy
            // 
            this.rdbEasy.AutoSize = true;
            this.rdbEasy.Location = new System.Drawing.Point(51, 50);
            this.rdbEasy.Name = "rdbEasy";
            this.rdbEasy.Size = new System.Drawing.Size(48, 17);
            this.rdbEasy.TabIndex = 0;
            this.rdbEasy.TabStop = true;
            this.rdbEasy.Text = "Easy";
            this.rdbEasy.UseVisualStyleBackColor = true;
            this.rdbEasy.CheckedChanged += new System.EventHandler(this.rdbEasy_CheckedChanged);
            // 
            // rdbNormal
            // 
            this.rdbNormal.AutoSize = true;
            this.rdbNormal.Location = new System.Drawing.Point(51, 90);
            this.rdbNormal.Name = "rdbNormal";
            this.rdbNormal.Size = new System.Drawing.Size(58, 17);
            this.rdbNormal.TabIndex = 1;
            this.rdbNormal.TabStop = true;
            this.rdbNormal.Text = "Normal";
            this.rdbNormal.UseVisualStyleBackColor = true;
            this.rdbNormal.CheckedChanged += new System.EventHandler(this.rdbNormal_CheckedChanged);
            // 
            // rdbQuick
            // 
            this.rdbQuick.AutoSize = true;
            this.rdbQuick.Location = new System.Drawing.Point(51, 47);
            this.rdbQuick.Name = "rdbQuick";
            this.rdbQuick.Size = new System.Drawing.Size(78, 17);
            this.rdbQuick.TabIndex = 0;
            this.rdbQuick.TabStop = true;
            this.rdbQuick.Text = "Quick Duel";
            this.rdbQuick.UseVisualStyleBackColor = true;
            this.rdbQuick.CheckedChanged += new System.EventHandler(this.rdbQuick_CheckedChanged);
            // 
            // rdbDeath
            // 
            this.rdbDeath.AutoSize = true;
            this.rdbDeath.Location = new System.Drawing.Point(51, 87);
            this.rdbDeath.Name = "rdbDeath";
            this.rdbDeath.Size = new System.Drawing.Size(79, 17);
            this.rdbDeath.TabIndex = 1;
            this.rdbDeath.TabStop = true;
            this.rdbDeath.Text = "Death Duel";
            this.rdbDeath.UseVisualStyleBackColor = true;
            this.rdbDeath.CheckedChanged += new System.EventHandler(this.rdbDeath_CheckedChanged);
            // 
            // lblHealthAI
            // 
            this.lblHealthAI.Location = new System.Drawing.Point(1078, 49);
            this.lblHealthAI.Name = "lblHealthAI";
            this.lblHealthAI.Size = new System.Drawing.Size(103, 23);
            this.lblHealthAI.TabIndex = 6;
            this.lblHealthAI.Text = "Health";
            // 
            // lblChangeAI
            // 
            this.lblChangeAI.Location = new System.Drawing.Point(1078, 82);
            this.lblChangeAI.Name = "lblChangeAI";
            this.lblChangeAI.Size = new System.Drawing.Size(103, 23);
            this.lblChangeAI.TabIndex = 7;
            this.lblChangeAI.Text = "Change";
            // 
            // lblAtkAI
            // 
            this.lblAtkAI.Location = new System.Drawing.Point(1078, 116);
            this.lblAtkAI.Name = "lblAtkAI";
            this.lblAtkAI.Size = new System.Drawing.Size(103, 23);
            this.lblAtkAI.TabIndex = 8;
            this.lblAtkAI.Text = "ATK";
            // 
            // lblDefAI
            // 
            this.lblDefAI.Location = new System.Drawing.Point(1212, 116);
            this.lblDefAI.Name = "lblDefAI";
            this.lblDefAI.Size = new System.Drawing.Size(103, 23);
            this.lblDefAI.TabIndex = 9;
            this.lblDefAI.Text = "DEF";
            // 
            // lblHealthPL
            // 
            this.lblHealthPL.Location = new System.Drawing.Point(1078, 438);
            this.lblHealthPL.Name = "lblHealthPL";
            this.lblHealthPL.Size = new System.Drawing.Size(103, 23);
            this.lblHealthPL.TabIndex = 10;
            this.lblHealthPL.Text = "Health";
            // 
            // lblChangePL
            // 
            this.lblChangePL.Location = new System.Drawing.Point(1078, 476);
            this.lblChangePL.Name = "lblChangePL";
            this.lblChangePL.Size = new System.Drawing.Size(103, 23);
            this.lblChangePL.TabIndex = 11;
            this.lblChangePL.Text = "Change";
            // 
            // lblAtkPL
            // 
            this.lblAtkPL.Location = new System.Drawing.Point(1078, 517);
            this.lblAtkPL.Name = "lblAtkPL";
            this.lblAtkPL.Size = new System.Drawing.Size(103, 23);
            this.lblAtkPL.TabIndex = 12;
            this.lblAtkPL.Text = "ATK";
            // 
            // lblDefPL
            // 
            this.lblDefPL.Location = new System.Drawing.Point(1212, 517);
            this.lblDefPL.Name = "lblDefPL";
            this.lblDefPL.Size = new System.Drawing.Size(103, 23);
            this.lblDefPL.TabIndex = 13;
            this.lblDefPL.Text = "DEF";
            // 
            // lblActions
            // 
            this.lblActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblActions.Location = new System.Drawing.Point(1078, 156);
            this.lblActions.Name = "lblActions";
            this.lblActions.Size = new System.Drawing.Size(237, 263);
            this.lblActions.TabIndex = 14;
            this.lblActions.Text = "lblActions";
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(51, 575);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(241, 48);
            this.btnNewGame.TabIndex = 15;
            this.btnNewGame.Text = "NEW GAME";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(323, 575);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(710, 48);
            this.btnChange.TabIndex = 16;
            this.btnChange.Text = "CHANGE CARDS";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnBattle
            // 
            this.btnBattle.Location = new System.Drawing.Point(1078, 575);
            this.btnBattle.Name = "btnBattle";
            this.btnBattle.Size = new System.Drawing.Size(237, 48);
            this.btnBattle.TabIndex = 17;
            this.btnBattle.Text = "BATTLE";
            this.btnBattle.UseVisualStyleBackColor = true;
            this.btnBattle.Click += new System.EventHandler(this.btnBattle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 661);
            this.Controls.Add(this.btnBattle);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.lblActions);
            this.Controls.Add(this.lblDefPL);
            this.Controls.Add(this.lblAtkPL);
            this.Controls.Add(this.lblChangePL);
            this.Controls.Add(this.lblHealthPL);
            this.Controls.Add(this.lblDefAI);
            this.Controls.Add(this.lblAtkAI);
            this.Controls.Add(this.lblChangeAI);
            this.Controls.Add(this.lblHealthAI);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblRules);
            this.Controls.Add(this.lblTurn);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Label lblRules;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbNormal;
        private System.Windows.Forms.RadioButton rdbEasy;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbDeath;
        private System.Windows.Forms.RadioButton rdbQuick;
        private System.Windows.Forms.Label lblHealthAI;
        private System.Windows.Forms.Label lblChangeAI;
        private System.Windows.Forms.Label lblAtkAI;
        private System.Windows.Forms.Label lblDefAI;
        private System.Windows.Forms.Label lblHealthPL;
        private System.Windows.Forms.Label lblChangePL;
        private System.Windows.Forms.Label lblAtkPL;
        private System.Windows.Forms.Label lblDefPL;
        private System.Windows.Forms.Label lblActions;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnBattle;
    }
}

