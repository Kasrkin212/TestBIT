using GalaSoft.MvvmLight;
using Chargily.Helpers;
using System;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Ioc;
using TestBIT.View;
using TestBIT.Views;

namespace TestBIT.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CityViewModel>();
            SimpleIoc.Default.Register<StreetViewModel>();
            SimpleIoc.Default.Register<HouseViewModel>();
            SimpleIoc.Default.Register<ApartmentViewModel>();
            SetupNavigation();
        }

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            navigationService.Configure("CityTable", new Uri("../View/CityTable.xaml", UriKind.Relative));
            navigationService.Configure("StreetTable", new Uri("../View/StreetTable.xaml", UriKind.Relative));
            navigationService.Configure("HouseTable", new Uri("../View/HouseTable.xaml", UriKind.Relative));
            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }
        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public CityViewModel CityViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CityViewModel>();
            }
        }
        public StreetViewModel StreetViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StreetViewModel>();
            }
        }
        public HouseViewModel HouseViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HouseViewModel>();
            }
        }
        public ApartmentViewModel ApartmentViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ApartmentViewModel>();
            }
        }
        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}
