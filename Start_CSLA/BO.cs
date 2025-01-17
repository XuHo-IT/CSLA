using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace Start_CSLA
{
    [Serializable]
    public class BO:BusinessBase<BO>
    {
        public static readonly PropertyInfo<int>
            IdProperty = RegisterProperty<int>(c => c.Id);
        public int Id
        {
            get => GetProperty<int>(IdProperty);
            set => SetProperty(IdProperty, value);
        }
        public static readonly PropertyInfo<string>
            NameProperty = RegisterProperty<string>(c => c.Name);
        public string Name
        {
            get=> GetProperty<string>(NameProperty);
            set => SetProperty(NameProperty, value);

        }
        protected override void AddBusinessRules()
        {
            BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(NameProperty));
        }
        [Fetch]
        private void DataPortal_Fetch(int id)
        {
            Id = id;
            Name = "Xuho";
        }
        [Create]
        private void DataPortal_Create()
        {
            Id = -1;
            Name = "New Person";
        }
    }
}
