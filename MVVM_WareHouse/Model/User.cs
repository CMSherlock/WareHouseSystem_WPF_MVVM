using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_WareHouse.Model
{
    class User
    {
        private string id;
        private string name;
        private string password;
        private bool isAdmin;

        public User(string id , string password, bool isAdmin, string name)
        {
            this.id = id;
            this.Name = name;
            this.password = password;
            this.isAdmin = isAdmin;
        }

        public string ID { get => id; set => id = value; }
        public string Password { get => password; set => password = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
        public string Name { get => name; set => name = value; }

        public override bool Equals(object obj)
        {
            var user = obj as User;
            return user != null &&
                   id == user.id &&
                   name == user.name &&
                   password == user.password &&
                   isAdmin == user.isAdmin;
        }

        public override int GetHashCode()
        {
            var hashCode = -70432292;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(password);
            hashCode = hashCode * -1521134295 + isAdmin.GetHashCode();
            return hashCode;
        }
    }
}
