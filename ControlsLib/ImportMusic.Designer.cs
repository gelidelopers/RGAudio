namespace ControlsLib
{
    partial class ImportMusic
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.radioButtonJingle = new System.Windows.Forms.RadioButton();
            this.radioButtonMusic = new System.Windows.Forms.RadioButton();
            this.radioButtonSintonia = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.colFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFileName,
            this.colName});
            this.listView1.Location = new System.Drawing.Point(3, 122);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(765, 341);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(674, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 58);
            this.button1.TabIndex = 1;
            this.button1.Text = "Importar al sistema";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFiles.Location = new System.Drawing.Point(3, 20);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(75, 58);
            this.btnAddFiles.TabIndex = 2;
            this.btnAddFiles.Text = "Afegir àudio";
            this.btnAddFiles.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(653, 90);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(115, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Borrar fitxer original";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(84, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 58);
            this.button3.TabIndex = 4;
            this.button3.Text = "Afegir carpeta plena d\'àudio";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // radioButtonJingle
            // 
            this.radioButtonJingle.AutoSize = true;
            this.radioButtonJingle.Location = new System.Drawing.Point(203, 69);
            this.radioButtonJingle.Name = "radioButtonJingle";
            this.radioButtonJingle.Size = new System.Drawing.Size(52, 17);
            this.radioButtonJingle.TabIndex = 6;
            this.radioButtonJingle.TabStop = true;
            this.radioButtonJingle.Text = "Jingle";
            this.radioButtonJingle.UseVisualStyleBackColor = true;
            // 
            // radioButtonMusic
            // 
            this.radioButtonMusic.AutoSize = true;
            this.radioButtonMusic.Location = new System.Drawing.Point(203, 14);
            this.radioButtonMusic.Name = "radioButtonMusic";
            this.radioButtonMusic.Size = new System.Drawing.Size(59, 17);
            this.radioButtonMusic.TabIndex = 5;
            this.radioButtonMusic.TabStop = true;
            this.radioButtonMusic.Text = "Música";
            this.radioButtonMusic.UseVisualStyleBackColor = true;
            // 
            // radioButtonSintonia
            // 
            this.radioButtonSintonia.AutoSize = true;
            this.radioButtonSintonia.Location = new System.Drawing.Point(203, 42);
            this.radioButtonSintonia.Name = "radioButtonSintonia";
            this.radioButtonSintonia.Size = new System.Drawing.Size(63, 17);
            this.radioButtonSintonia.TabIndex = 7;
            this.radioButtonSintonia.TabStop = true;
            this.radioButtonSintonia.Text = "Sintonia";
            this.radioButtonSintonia.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(272, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(206, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(272, 41);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(206, 21);
            this.comboBox2.TabIndex = 9;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(272, 68);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(206, 21);
            this.comboBox3.TabIndex = 10;
            // 
            // colFileName
            // 
            this.colFileName.Text = "Fitxer";
            // 
            // colName
            // 
            this.colName.Text = "Nom";
            // 
            // ImportMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.radioButtonSintonia);
            this.Controls.Add(this.radioButtonJingle);
            this.Controls.Add(this.radioButtonMusic);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnAddFiles);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Name = "ImportMusic";
            this.Size = new System.Drawing.Size(771, 466);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton radioButtonJingle;
        private System.Windows.Forms.RadioButton radioButtonMusic;
        private System.Windows.Forms.RadioButton radioButtonSintonia;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ColumnHeader colFileName;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ComboBox comboBox3;
    }
}
