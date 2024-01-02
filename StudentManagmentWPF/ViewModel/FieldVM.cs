using StudentManagmentWPF.Data;
using StudentManagmentWPF.Model;
using StudentManagmentWPF.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentWPF.ViewModel
{
    class FieldVM : ViewModelBase
    {
        public int _itemsPerPage;
        public int ItemsPerPage
        {
            get { return _itemsPerPage; }
            set
            {
                if (_itemsPerPage != value)
                {
                    _itemsPerPage = value;
                    OnPropertyChanged(nameof(ItemsPerPage));
                }
            }
        }
        private Field _obj;
        public Field Obj
        {
            get { return _obj; }
            set
            {
                if (_obj != value)
                {
                    _obj = value;
                    OnPropertyChanged(nameof(Obj));
                }
            }
        }
        public void AddElemet(Field obj)
        {
            _db.Add(obj);
            _db.SaveChanges();
            ResetFields();
        }
        public void ResetFields()
        {
            ObservableCollection<Field> t_fields = new ObservableCollection<Field>();
            foreach (var field in _db.Fields)
            {
                t_fields.Add(field);
            }
            if (t_fields.Count >= 5)
            {
                ItemsPerPage = 5;
            }
            else if (t_fields.Count >= 3)
            {
                ItemsPerPage = 3;
            }
            else
            {
                ItemsPerPage = 1;
            }
            Fields = t_fields;
        }
        public void EditItem(Field newObj)
        {
            if (_obj!=null)
            {
                var fieldToEdit = _db.Fields.Find(_obj.Id);

                if (fieldToEdit != null)
                {
                    fieldToEdit.Nom = newObj.Nom;
                    fieldToEdit.Responsable = newObj.Responsable;

                    _db.SaveChanges();
                }
                ResetFields();
            }
        }
        public void deleteSelectedItem()
        {
            if (_obj !=null)
            {
                var fieldToDelete = _db.Fields.Find(_obj.Id);

                if (fieldToDelete != null)
                {
                    _db.Fields.Remove(fieldToDelete);

                    _db.SaveChanges();
                }

                ResetFields();
            }
        }
        private ObservableCollection<Field> _fields;
        public ObservableCollection<Field> Fields
        {
            get { return _fields; }
            set
            {
                _fields = value;
                OnPropertyChanged(nameof(Fields));
            }
        }
        SchoolDbContext _db = new SchoolDbContext();
        public FieldVM()
        {
            _fields = new ObservableCollection<Field>();

            //// Add items from _dbFields to _fields
            foreach (var field in _db.Fields)
            {
                _fields.Add(field);
            }

            ResetFields();
        }
    }
}