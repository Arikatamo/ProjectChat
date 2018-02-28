using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Abstract;
using Chat_Library.Abstract;
using Chat_Library.Concrete;

using Chat_Library;

namespace BLL.Concrete
{
    public class UserProvider: iUserProvider
    {
        private readonly iUserRepository _iUserRepository;
        private readonly iUserContactList _iUserContactList;
        private readonly iMsgRepository _iMsgRepository;
        private readonly iSenderRepository _iSenderRepository;

       public UserProvider()
        {
            Context context = new Context();
            _iMsgRepository = new MsgRepository(context);
            _iSenderRepository = new SenderRepository(context);
            _iUserContactList = new ContactsRepository(context);
            _iUserRepository = new UserRepository(context);
        }

        public void AddContacts(tblUser user, tblUser userToAdd)
        {
            tblContactList contact = new tblContactList
            {
                MyId = user.id,
                UserId = userToAdd.id
            };
            _iUserContactList.AddContact(contact);
            _iUserContactList.SaveChanges();
        }

        public void AddMsg(string text, int ID)
        {
            tblMessage msg = new tblMessage
            {
                Message = text,
                UserID = ID,
                SendDate = DateTime.Now
            };
            _iMsgRepository.AddMessage(msg);
            _iMsgRepository.SaveChanges();
        }

        public tblUser AddUser(string name, string phone, string image)
        {

            tblUser user = new tblUser
            {
                Name = name,
                Phone = phone,
                Image = image,
                DateCreate = DateTime.Now
            };
            _iUserRepository.AddUser(user);

            if (_iUserRepository.GetAll().FirstOrDefault(x=>x.Name == name) != null || _iUserRepository.GetAll().FirstOrDefault(x => x.Phone == phone) != null)
            {
                throw new Exception("This user alredy in Base");
            }
            else
            {
                _iUserRepository.SaveChanges();
                return user;
            }

        }

        public IList<tblUser> GetAllContacts(tblUser user)
        {
           var Contacts = _iUserContactList.GetAllContacts().Where(x => x.MyId == user.id);
            IList<tblUser> users = null;
            try
            {
                foreach (var item in Contacts)
                {
                    users.Add(_iUserRepository.GetAll().FirstOrDefault(x => x.id == item.UserId));
                }
                return users;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }

        public IList<tblMessage> GetAllMsg()
        {
            return _iMsgRepository.GetAllMsg().ToList();
        }

        public IList<tblUser> GetAllUsers()
        {
            return _iUserRepository.GetAll().ToList();

        }
    }
}
