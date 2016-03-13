using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Program_5_CheckSudoku_Wingo
{
    public partial class Form1 : Form
    {
        readonly int[,] board;
        int size = 9;

        HashSet<int>[] rowSet;
        HashSet<int>[] colSet;
        HashSet<int>[] blkSet;

        public Form1()
        {
            InitializeComponent();

            board = new int[size, size];

            rowSet = new HashSet<int>[size];
            colSet = new HashSet<int>[size];
            blkSet = new HashSet<int>[size];

            
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFile.Text = openFileDialog.FileName;
                ReadTextFile();

                lstResult.Items.Clear();
                lbValid.Text = "";

                InitSet(rowSet);
                InitSet(colSet);
                InitSet(blkSet);
            }
        }

        private void btCheck_Click(object sender, EventArgs e)
        {
            if (txtFile.Text == "")
                MessageBox.Show("Please select input text file!");
            else
            {
                CheckRow();
                CheckColumn();
                CheckBlock();

                if (lstResult.Items.Count > 0)
                    lbValid.Text = "INVALID";
                else lbValid.Text = "VALID";
            }
        }

        
        private void ReadTextFile()
        {
            try
            {
                StreamReader sr = new StreamReader(txtFile.Text.Trim());
                for (int i = 0; i < size; i++)
                {
                    string strLine = sr.ReadLine();
                    string[] num = strLine.Split(',');
                    for (int j = 0; j < size; j++)
                        board[i, j] = int.Parse(num[j]);
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error read text file: " + ex.Message);
            }
        }

        private void InitSet(HashSet<int>[] set)
        {
            for (int i = 0; i < size; i++)
                set[i] = new HashSet<int>();
        }

        private void CheckRow()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    int val = board[row, col];

                    if (rowSet[row].Contains(val))
                    {
                        string item = "ROW: " + row;
                        if (!lstResult.Items.Contains(item))
                            lstResult.Items.Add("ROW: " + row);
                    }

                    rowSet[row].Add(val);
                }
            }
            
        }

        private void CheckColumn()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    int val = board[row, col];

                    if (colSet[col].Contains(val))
                    {
                        string item = "COL: " + col;
                        if (!lstResult.Items.Contains(item))
                            lstResult.Items.Add(item);
                    }

                    colSet[col].Add(val);
                }
            }
        }

        private void CheckBlock()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    int val = board[row, col];
                    int block = col / 3 + row / 3 * 3;

                    if (blkSet[block].Contains(val))
                    {
                        string item = "BLK :" + block;
                        if(!lstResult.Items.Contains(item))
                            lstResult.Items.Add(item);
                    }

                    blkSet[block].Add(val);
                }
            }
        }
       
    }
}
