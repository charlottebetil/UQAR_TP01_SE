using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp01_SE
{
    public partial class PrincipalForm : Form
    {
        List<Processus> lstProcessus;
        Color[,] bgColors;
        Boolean bgColorsOk = false;
        int rowCountMax = 0;
        

        //    Color[,] bgColors = new Color[2, 8] {
        //{ SystemColors.Control, SystemColors.Control,SystemColors.Control,SystemColors.Control,SystemColors.Control,SystemColors.Control,SystemColors.Control, SystemColors.Control },
        //{ SystemColors.Control, SystemColors.Control,SystemColors.Control,SystemColors.Control,SystemColors.Control,SystemColors.Control,SystemColors.Control, SystemColors.Control }
        //    };

        public PrincipalForm()
        {
            InitializeComponent();
            this.lstProcessus = new List<Processus>();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenue sur l'outil: Ordonnanceur\n" +
                            "Version: Beta\n" +
                            "Author: Bétil Charlotte & Chevallier Pierre\n" +
                            "Organisation: UQAR\n");
        }

        private void btnLancer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lancement de la simulation");
            //Algo principale
            
            if (lstProcessus.Count > 1) 
            {               
                List<Processus> orderedListProcessus3 = new List<Processus>();
                orderedListProcessus3.AddRange(OrderListProcessus(lstProcessus));                
                
                launchProcessus(orderedListProcessus3);
            }
            else
            {
                launchProcessus(this.lstProcessus);
            }
            

            ////Algo test
            //lstProcessus.First().getThreads().First().getInstructions().First().Etat = Enums.etat.EnCours;
            //updateCouleur();
            //System.Threading.Thread.Sleep(3000);
            //lstProcessus.First().getThreads().First().getInstructions().First().Etat = Enums.etat.Termine;
            //lstProcessus.First().getThreads().First().getInstructions()[2].Etat = Enums.etat.EnCours;
            //updateCouleur();
            //System.Threading.Thread.Sleep(3000);
            //lstProcessus.First().getThreads().First().getInstructions()[2].Etat = Enums.etat.Termine;
            //updateCouleur();
            //lstProcessus.First().getThreads().First().getInstructions().First().Etat = Enums.etat.EnCours;
            //updateCouleur();
            //System.Threading.Thread.Sleep(3000);
            //lstProcessus.First().getThreads().First().getInstructions().First().Etat = Enums.etat.Termine;
            //lstProcessus.First().getThreads().First().getInstructions()[1].Etat = Enums.etat.EnCours;
            //updateCouleur();
            //System.Threading.Thread.Sleep(3000);
            //lstProcessus.First().getThreads().First().getInstructions()[1].Etat = Enums.etat.Termine;
            //updateCouleur();

        }

        private void btnAjout_Click(object sender, EventArgs e)
        {
            Form form = new AddProcessForm(ref this.lstProcessus);
            form.ShowDialog();
            this.displayLstThread();
        }

        private void btnSup_Click(object sender, EventArgs e)
        {
            bgColorsOk = false;
            Form form = new SupProcessForm(ref this.lstProcessus);
            form.ShowDialog();            
            this.displayLstThread();
            
        }

        private void displayLstThread()
        {         
            tblRAM.Controls.Clear();
            tblRAM.RowCount = 1;
            tblRAM.ColumnCount = 0;
            foreach (Processus process in this.lstProcessus)
            {
                tblRAM.RowCount = 1;
                foreach(Thread thread in process.getThreads())
                {
                    tblRAM.ColumnCount++;                    
                    tblRAM.RowCount = 1;                                                                                                         
                    tblRAM.RowStyles.Add(new RowStyle(SizeType.Absolute));                   
                    Label lbl = new Label();
                    lbl.Height = 70;
                    lbl.BackColor = Color.Transparent;
                    lbl.Text = thread.getInfoThread();
                    tblRAM.Controls.Add(lbl, tblRAM.ColumnCount - 1, tblRAM.RowCount - 1);                                   
                    foreach (Instruction instruct in thread.getInstructions())
                    {                                               
                        tblRAM.RowCount++;
                        Label lbl2 = new Label();
                        lbl2.Height = 25;
                        lbl2.BackColor = Color.Transparent;
                        lbl2.Text = instruct.Type.ToString();
                        tblRAM.Controls.Add(lbl2, tblRAM.ColumnCount - 1, tblRAM.RowCount - 1);
                        if (rowCountMax < tblRAM.RowCount)
                        {
                            rowCountMax = tblRAM.RowCount;
                        }
                    }
                }
            }
            TableLayoutRowStyleCollection styles = tblRAM.RowStyles;
            foreach (RowStyle style in styles)
            {
                if (style.SizeType == SizeType.Absolute)
                {
                    style.Height = 30;
                }
                else
                {
                    style.Height = 100;
                }
            }
            createCellColor(tblRAM.ColumnCount, rowCountMax + 1);
        }
        private void createCellColor(int column, int row)
        {
            bgColors = new Color[column, row];
            for (int i = 0; i < column; i++)
            {                
                for (int y = 0; y < row; y++)
                {
                    bgColors[i, y] = SystemColors.Control;
                }                
            }
            bgColorsOk = true;
            tblRAM.Refresh();
            bgColorsOk = false;
        }          

        private void tblRAM_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {          
            if (bgColorsOk == true && lstProcessus.Count !=0)
            {                
                using (var b = new SolidBrush(bgColors[e.Column, e.Row]))
                {
                    e.Graphics.FillRectangle(b, e.CellBounds);
                }                
            }
        }

        private void updateCouleur()
        {
            int column = 0;
            foreach (Processus process in lstProcessus)
            {                
                foreach (Thread thread in process.getThreads())
                {
                    int row = 1;
                    foreach (Instruction instruction in thread.getInstructions())
                    {                        
                        if (instruction.Etat.Equals(Enums.etat.EnCours))
                        {
                            bgColors[column, row] = Color.Red;
                            bgColorsOk = true;
                            tblRAM.Refresh();
                        }
                        if (instruction.Etat.Equals(Enums.etat.Termine))
                        {
                            bgColors[column, row] = Color.LightGray;
                            bgColorsOk = true;
                            tblRAM.Refresh();
                        }
                        if (instruction.Etat.Equals(Enums.etat.Initialise))
                        {
                            bgColors[column, row] = Color.Blue;
                            bgColorsOk = true;
                            tblRAM.Refresh();
                        }
                        row++;
                    }
                    column++;
                }
            }
            bgColorsOk = false;
        }
        private List<Processus> OrderListProcessus(List<Processus> newlistProcessus)
        {
            List<Processus> newlist = new List<Processus>();
            newlist.AddRange(newlistProcessus);

            int lenght = newlistProcessus.Count;
            int i = 0;
            label1.Text = "";
            while (lenght>0)
            {
                for (i = 0; i < lenght - 1; i++)
                {
                    if (newlist[i].getEstimatedExecutionTime() > newlist[i+1].getEstimatedExecutionTime())
                    {
                        Processus processus = newlist[i];
                        newlist[i] = newlist[i+1];
                        newlist[i + 1] = processus;
                    }
                }
                lenght = lenght - 1;
                label1.Text=label1.Text+"\n Processus: "+ newlist[i].getName() + "    EstimatedTime: "+ newlist[i].getEstimatedExecutionTime();
            }
            return newlist;
        }

        private void launchProcessus(List<Processus> orderedListPRocessus) 
        {
            foreach(Processus processus in orderedListPRocessus)
            {
                foreach(Thread thread in processus.getThreads())
                {
                    foreach(Instruction instruction in thread.getInstructions())
                    {
                        instruction.Etat = Enums.etat.EnCours;
                        updateCouleur();
                        sleep(instruction);
                        instruction.Etat = Enums.etat.Termine;
                        updateCouleur();
                    }
                }
            }
        }

        private void sleep(Instruction instruction)
        {
            if (instruction.Type == Enums.type.Calcul)
            {
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                System.Threading.Thread.Sleep(3000);
            }
        }

    }
}
