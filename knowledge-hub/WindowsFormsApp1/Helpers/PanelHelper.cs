using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace knowledge_hub.Desktop.Helpers
{
   public class PanelHelper
   {
      public static void ClearPanels(Control container) {
         container.Controls.Clear();
      }

      public static void AddPanel(Control container, UserControl panel) {
         if (!container.Controls.Contains(panel))
         {
            container.Controls.Add(panel);
            panel.Dock = DockStyle.Fill;
         }
         panel.BringToFront();
      }

      public static void RemovePanel(Control container, UserControl panel) {
         container.Controls.Remove(panel);
      }

      public static void SwapPanel(Control container, UserControl oldPanel, UserControl newPanel) {
         RemovePanel(container, oldPanel);
         AddPanel(container, newPanel);
      }
   }
}
