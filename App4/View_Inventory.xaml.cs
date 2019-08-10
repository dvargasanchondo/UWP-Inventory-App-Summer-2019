using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.Storage;
using System.Net.Http;
using Newtonsoft.Json;
using Windows.UI.Core;
using Windows.System;
using static App4.Models.Inventory;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using App4.Models;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class View_Inventory : Page
    {
        public event TypedEventHandler<AutoSuggestBox, AutoSuggestBoxQuerySubmittedEventArgs> QuerySubmitted;
        public View_Inventory()
        {
            this.InitializeComponent();
            ListItems.ItemsSource = items;

        }

        

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            BackButton1.IsEnabled = this.Frame.CanGoBack;
            await RefreshTodoItems();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            On_BackRequested();
        }

        // Handles system-level BackRequested events and page-level back button Click events
        private bool On_BackRequested()
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                return true;
            }
            return false;
        }

        private void BackInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            On_BackRequested();
            args.Handled = true;
        }

        IMobileServiceTable<TodoItem> todoTable = App.MobileService.GetTable<TodoItem>();
                MobileServiceCollection<TodoItem, TodoItem> items;
       
        
        private async Task RefreshTodoItems()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                // This code refreshes the entries in the list view by querying the TodoItems table.
                // The query excludes completed TodoItems
                items = await todoTable
                    .ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }

            if (exception != null)
            {
                await new MessageDialog(exception.Message, "Error loading items").ShowAsync();
            }
            else
            {
                ListItems.ItemsSource = items;
                
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await RefreshTodoItems();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }


        private async void Box1_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            MobileServiceInvalidOperationException exception = null;


            try
            {
 
                var search_term = args.QueryText;
                items = await todoTable.Where(TodoItem => TodoItem.PartName.Contains(search_term) && TodoItem.iPhoneModel.Contains(search_term))
                   .ToCollectionAsync();
               
                
            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }

            if (exception != null)
            {
                await new MessageDialog(exception.Message, "Error loading items").ShowAsync();
            }
            else
            {
                ListItems.ItemsSource = items;
                
            }
        }

        private async void Box1_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            MobileServiceInvalidOperationException exception = null;

            

                try
                {

                    var search_term = sender.Text;
                    items = await todoTable.Where(TodoItem => TodoItem.PartName.Contains(search_term) | TodoItem.iPhoneModel.Contains(search_term) | TodoItem.SKU.Contains(search_term) | TodoItem.Category.Contains(search_term))
                       .ToCollectionAsync();
     
                     


            }
                catch (MobileServiceInvalidOperationException e)
                {
                    exception = e;
                }

                if (exception != null)
                {
                    await new MessageDialog(exception.Message, "Error loading items").ShowAsync();
                }
                else
                {
                    ListItems.ItemsSource = items;

                }

            
        }

        private async void ComboBox1_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var dialog = new MessageDialog("Successful!");
            await dialog.ShowAsync();
        }

        private async void SymbolIcon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentDialog deleterowdialog = new ContentDialog
            {
                Title = "Delete inventory Entry?",
                Content = "All information on this item will be lost.",
                PrimaryButtonText = "Delete",
                CloseButtonText = "Cancel"
            };
            ContentDialogResult result = await deleterowdialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                TodoItem item = this.ListItems.SelectedItem as TodoItem;
                await App.MobileService.GetTable<TodoItem>().DeleteAsync(item);
                await RefreshTodoItems();
                var dialog = new MessageDialog("Row Deleted");
                await dialog.ShowAsync();

            }
            else
            {

            }
            
          

            
        }

        private async void SymbolIcon_Tapped_1(object sender, TappedRoutedEventArgs e)
        {

            //TodoItem item =  as TodoItem;
            //await App.MobileService.GetTable<TodoItem>().UpdateAsync(item);
            //await RefreshTodoItems();


            //      CoreApplicationView newCoreView = CoreApplication.CreateNewView();

            //      ApplicationView newAppView = null;
            //      int mainViewId = ApplicationView.GetApplicationViewIdForWindow(
            //        CoreApplication.MainView.CoreWindow);

            //      await newCoreView.Dispatcher.RunAsync(
            //CoreDispatcherPriority.Normal,
            //() =>
            //{
            //    newAppView = ApplicationView.GetForCurrentView();
            //    Window.Current.Content = new Frame();
            //    (Window.Current.Content as Frame).Navigate(typeof(UpdateStock));
            //    Window.Current.Activate();
            //});

            //      await ApplicationViewSwitcher.TryShowAsStandaloneAsync(
            //      newAppView.Id,
            //      ViewSizePreference.UseHalf,
            //      mainViewId,
            //      ViewSizePreference.UseHalf);

        }


        private void button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }
        private void button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }

       


    }
    }
    

