using knowledge_hub.Models.Model.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static knowledge_hub.Models.Model.Enums;

namespace WindowsFormsApp1.Forms.Transactions
{
   public partial class OrderPreview : Form
   {
      public OrderPreview(OrderResponse order) {
         InitializeComponent();

         OrderNumberLabel.Text = "Order Number: " + order.OrderNumber;
         UserFullnameLabel.Text = "Full Name: " + order.UserFullName;
         BookNameLabel.Text = "Book Name: " + order.Book.Name;
         OrderDateLabel.Text = "Order Date: " + order.OrderDate;
         ShippingDateLabel.Text = "Shipping Date: " + order.ShippingDate;
         OrderStatusLabel.Text = "Status: " + GetOrderStatusAsString(order.OrderStatus);
         CommentLabel.Text = "Comment: " + order.Comment;
         AddressLabel.Text = "Address: " + order.AddressLine;
         CityLabel.Text = "City: " + order.City;
      }

      string GetOrderStatusAsString(int status) {
         var orderStatus = (OrderStatus)status;
         switch (orderStatus)
         {
            case OrderStatus.Placed:
               return "Placed";
            case OrderStatus.Shipped:
               return "Shipped";
            case OrderStatus.Canceled:
               return "Canceled";
            default:
               return "Unknown";
         }
      }

      private void button1_Click(object sender, EventArgs e) {
         this.Hide();
      }
   }
}
