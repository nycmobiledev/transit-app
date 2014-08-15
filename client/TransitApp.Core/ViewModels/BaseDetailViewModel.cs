using System;

namespace TransitApp.Core.ViewModels
{
    public abstract class BaseDetailViewModel<TData> : BaseViewModel<TData> where TData : new()
    {


        protected BaseDetailViewModel () : base ()
        {
        }


    }
}

