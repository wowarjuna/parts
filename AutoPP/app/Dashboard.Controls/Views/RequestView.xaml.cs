using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dashboard.Controls.WcfRequestService;

namespace Dashboard.Controls.Views
{
    /// <summary>
    /// Interaction logic for RequestView.xaml
    /// </summary>
    public partial class RequestView : UserControl
    {
        public RequestView()
        {
            InitializeComponent();
            LoadRequests();
        }

        private void LoadRequests()
        {
            RequestServiceClient _proxy = new RequestServiceClient();
            foreach(var _request in _proxy.GetRequests("0B1802C1-D2B6-48C4-89AA-74D3AA2D19B1"))
            {
                RequestContainer.Children.Add(new TextBlock { Text = _request.Description });
            }
            
        }
    }
}
