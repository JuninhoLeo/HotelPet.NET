using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelPet.Functions
{
    static public class InterfaceTools
    {
        static public void dgvTransformation(DataGridView dgv)
        {
            //dgv.BackgroundColor = Color.FromName("White");
            //dgv.BorderStyle = 0; //0 = none
            //dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            //dgv.ColumnHeadersVisible = true;
            //dgv.EnableHeadersVisualStyles = false;
            //dgv.GridColor = Color.FromName("ActiveCaption");
            dgv.AutoGenerateColumns = false;
            //DataGridViewRow row = new DataGridViewRow();
            //row.Height = 200;

            dgv.RowTemplate.MinimumHeight = 80;

        }
    }
}
