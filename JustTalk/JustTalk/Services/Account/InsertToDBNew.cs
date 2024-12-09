using JustTalk.justTalkModels;

namespace JustTalk.Services.Account
{
    public class InsertToDBNew
    {
        User user;
        justTalkContext db;
        public InsertToDBNew(User user)
        {
            this.user = user;
            db = new justTalkContext();
        }

        private bool checkIfExistsAccount()
            =>
            db.Users.Where(item => item.Nick == user.Nick).Count() > 0;

        internal bool insertNewUser()
        {
            if (checkIfExistsAccount())
                return false;


            db.Users.Add(new User()
            {
                Nick = user.Nick, 
                PlayableNick = user.Nick,
                Password = user.Password,
                Email = user.Email,
                UserCreated = DateTime.Now
            });

            return db.SaveChanges() > 0;
        }
    }
}
