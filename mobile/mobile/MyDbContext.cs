using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using mobile.Models;
using System.Data;
using System.Linq;

namespace mobile
{
    public class MyDbContext
    {
        private readonly SQLiteConnection conn;
        public MyDbContext(string path)
        {
            conn = new SQLiteConnection(path);
            conn.CreateTable<Users>();
            conn.CreateTable<Roles>();
        }





        public List<Roles> GetRoles()
        {
            return conn.Table<Roles>().ToList();
        }
        public string GetRole(int a)
        {
            return conn.Table<Roles>().FirstOrDefault(x => x.id_r == a).name_r;
        }





        public List<G_D> GetGDs()
        {
            var users = conn.Table<G_D>().OrderBy(x => x.id_g).ToList();
            foreach (var user in users)
            {
                var disc = conn.Table<Discs>().FirstOrDefault(r => r.id_d == user.id_d);
                user.name_d = disc?.name_d;
                var us = conn.Table<Groups>().FirstOrDefault(r => r.id_g == user.id_g);
                user.num_g = us?.num_g;
            }
            return users;
        }
        public int SaveGD(G_D item)
        {
            if (conn.Table<G_D>().Where(x => x.id_g == item.id_g && x.id_d == item.id_d).FirstOrDefault() == null)
            {
                if (item.id_g_d != 0)
                {
                    conn.Update(item);
                    return item.id_g_d;
                }
                else
                {
                    return conn.Insert(item);
                }
            }
            return 0;
        }
        public int DeleteGD(int id)
        {
            return conn.Delete<G_D>(id);
        }





        public List<U_D> GetUDs()
        {
            var users = conn.Table<U_D>().ToList();
            foreach (var user in users)
            {
                var disc = conn.Table<Discs>().FirstOrDefault(r => r.id_d == user.id_d);
                user.name_d = disc?.name_d;
                var us = conn.Table<Users>().FirstOrDefault(r => r.id_u == user.id_u);
                user.fio_u = us?.fio_u;
            }
            return users;
        }
        public int SaveUD(U_D item)
        {
            if (conn.Table<U_D>().Where(x => x.id_u == item.id_u && x.id_d == item.id_d).FirstOrDefault() == null)
            {
                if (item.id_u_d != 0)
                {
                    conn.Update(item);
                    return item.id_u_d;
                }
                else
                {
                    return conn.Insert(item);
                }
            }
            return 0;
        }
        public int DeleteUD(int id)
        {
            return conn.Delete<U_D>(id);
        }





        public int GetUser(string a)
        {
            return conn.Table<Users>().FirstOrDefault(x => x.fio_u == a).id_u;
        }
        public List<Users> GetUsers()
        {
            return conn.Table<Users>().OrderBy(x => x.fio_u).ToList();
        }
        public List<Users> GetUsersT()
        {
            return conn.Table<Users>().Where(x => x.role_u == 2).ToList();
        }
        public int SaveUser(Users item)
        {
            if (conn.Table<Users>().Where(x => x.login_u == item.login_u && x.pass_u == item.pass_u).FirstOrDefault() == null)
            {
                if (item.id_u != 0)
                {
                    conn.Update(item);
                    return item.id_u;
                }
                else
                {
                    return conn.Insert(item);
                }
            }
            return 0;
        }
        public int DeleteUser(int id)
        {
            return conn.Delete<Users>(id);
        }
        public List<Users> GetUsers1()
        {
            return conn.Table<Users>().Where(x => x.role_u == 2).ToList();
        }





        public List<News> GetNews()
        {
            return conn.Table<News>().OrderBy(x => x.zag).ToList();
        }
        public int SaveNews(News item)
        {
            if (conn.Table<News>().Where(x => x.zag == item.zag && x.txt == item.txt && x.txt1 == item.txt1).FirstOrDefault() == null)
            {
                if (item.id != 0)
                {
                    conn.Update(item);
                    conn.Update(item);
                    return item.id;
                }
                else
                {
                    return conn.Insert(item);
                }
            }
            return 0;
        }
        public int DeleteNews(int id)
        {
            return conn.Delete<News>(id);
        }
        public News GetNewsZag(string a)
        {
            return conn.Table<News>().FirstOrDefault(x => x.zag == a);
        }
        public News GetNews1(int a)
        {
            return conn.Table<News>().Where(x => x.id == a).FirstOrDefault();
        }





        public List<Groups> GetGroups()

        {
            return conn.Table<Groups>().OrderBy(x => x.num_g).ToList();
        }
        public int SaveGroup(Groups item)
        {
            if (conn.Table<Groups>().Where(x => x.num_g == item.num_g).FirstOrDefault() == null)
            {
                if (item.id_g != 0)
                {
                    conn.Update(item);
                    return item.id_g;
                }
                else
                {
                    return conn.Insert(item);
                }
            }
            return 0;
        }
        public int DeleteGroup(int id)
        {
            return conn.Delete<Groups>(id);
        }
        public string GetGroup(int a)
        {
            return conn.Table<Groups>().FirstOrDefault(x => x.id_g == a).num_g;
        }
        public int GetGroup(string a)
        {
            return conn.Table<Groups>().FirstOrDefault(x => x.num_g == a).id_g;
        }





        public List<Vidi> GetVidi()
        {
            return conn.Table<Vidi>().ToList();
        }
        public Vidi GetVid(string a)
        {
            return conn.Table<Vidi>().Where(x => x.name_v == a).FirstOrDefault();
        }
        public int GetVid1(string a)
        {
            return conn.Table<Vidi>().Where(x => x.name_v == a).FirstOrDefault().id_v;
        }
        public string GetVid(int a)
        {
            return conn.Table<Vidi>().Where(x => x.id_v == a).FirstOrDefault().name_v;
        }





        public Discs GetDisc(string a)
        {
            return conn.Table<Discs>().Where(x => x.name_d == a).FirstOrDefault();
        }
        public int GetDisc1(string a)
        {
            return conn.Table<Discs>().FirstOrDefault(x => x.name_d == a).id_d;
        }
        public string GetDisc(int a)
        {
            return conn.Table<Discs>().FirstOrDefault(x => x.id_d == a).name_d;
        }
        public List<Discs> GetDiscs()
        {
            return conn.Table<Discs>().OrderBy(x => x.name_d).ToList();
        }
        public int SaveDisc(Discs item)
        {
            if (conn.Table<Discs>().Where(x => x.name_d == item.name_d).FirstOrDefault() == null)
            {
                if (item.id_d != 0)
                {
                    conn.Update(item);
                    return item.id_d;
                }
                else
                {
                    return conn.Insert(item);
                }
            }
            return 0;
        }
        public int DeleteDisc(int id)
        {
            return conn.Delete<Discs>(id);
        }
        public List<G_D> GetDiscs(int a)
        {
            var users = conn.Table<G_D>().Where(x => x.id_g == a).ToList();
            foreach (var user in users)
            {
                var disc = conn.Table<Discs>().FirstOrDefault(r => r.id_d == user.id_d);
                user.name_d = disc?.name_d;
            }
            return users;
        }
        public List<U_D> GetDiscsT(int a)
        {
            var users = conn.Table<U_D>().Where(x => x.id_u == a).ToList();
            foreach (var user in users)
            {
                var disc = conn.Table<Discs>().FirstOrDefault(r => r.id_d == user.id_d);
                user.name_d = disc?.name_d;
            }
            return users;
        }





        public int SaveOtchet(Otcheti item)
        {
            return conn.Insert(item);
        }
        public List<Otcheti> GetOtcheti(int b, int c)
        {
            var users = conn.Table<Otcheti>().ToList();
            foreach (var user in users)
            {
                var a = conn.Table<Doki>().FirstOrDefault(r => r.id_di == c && r.id_v == b);
                user.id_di = a.id_di;
                user.id_v = a.id_v;
                var disc = conn.Table<Users>().FirstOrDefault(r => r.id_u == user.id_u);
                user.fio_u = disc.fio_u;
            }
            users = conn.Table<Otcheti>().Where(x => x.id_v == b && x.id_di == c).ToList();
            return users;
        }





        public Doki GetDok1(string a, int b, int c)
        {
            return conn.Table<Doki>().Where(x => x.name_d == a && x.id_v == b && x.id_di == c).FirstOrDefault();
        }
        public List<Doki> GetDoki(int b, int c)
        {
            return conn.Table<Doki>().Where(x => x.id_v == b && x.id_di == c).ToList();
        }
        public List<Doki> GetDoki1(int b, int c)
        {
            return conn.Table<Doki>().Where(x => x.id_v == b && x.id_di == c && x.flag_d == 1).ToList();
        }
        public string GetDok(string a, int b, int c)
        {
            return conn.Table<Doki>().Where(x => x.name_d == a && x.id_v == b && x.id_di == c).FirstOrDefault().ssilka_d;
        }
        public List<Doki> GetDoki2(int b, int c)
        {
            var users = conn.Table<Doki>().Where(x => x.id_v == b && x.id_di == c).ToList();
            foreach (var user in users)
            {
                var disc = conn.Table<Discs>().FirstOrDefault(r => r.id_d == user.id_di);
                user.name_di = disc.name_d;
                var vid = conn.Table<Vidi>().FirstOrDefault(r => r.id_v == user.id_v);
                user.name_v = vid.name_v;
            }
            return users;
        }
        public int SaveDoki(Doki item)
        {
            if (conn.Table<Doki>().Where(x => x.name_d == item.name_d && x.id_di == item.id_di && x.id_v == item.id_v && x.flag_d == item.flag_d).FirstOrDefault() == null)
            {
                if (item.id_d != 0)
                {
                    conn.Update(item);
                    return item.id_d;
                }
                else
                {
                    return conn.Insert(item);
                }
            }
            return 0;
        }
        public int DeleteDoki(int id)
        {
            return conn.Delete<Doki>(id);
        }





        public List<Raspis> GetRaspis1(string a, int i)
        {            
            int gr = conn.Table<Groups>().Where(u => u.num_g == a).FirstOrDefault().id_g;
            var users = conn.Table<Raspis>().ToList();
            if (i == 0)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 1 && (u.id_c == 1 || u.id_c == 3) && u.id_g == gr).ToList();
            if (i == 1)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 1 && (u.id_c == 2 || u.id_c == 3) && u.id_g == gr).ToList();

            foreach (var user in users)
            {
                var time = conn.Table<Times>().FirstOrDefault(r => r.id_t == user.id_t);
                var disc = conn.Table<Discs>().FirstOrDefault(r => r.id_d == user.id_d);
                var vid = conn.Table<Vidi>().FirstOrDefault(r => r.id_v == user.id_v);
                var user1 = conn.Table<Users>().FirstOrDefault(r => r.id_u == user.id_u);
                user.name_t = time?.name_t;
                user.name_d = disc?.name_d;
                user.name_v = vid?.name_v;
                user.fio_u = user1?.fio_u;
            }
            return users;
        }
        public List<Raspis> GetRaspis2(string a, int i)
        {
            int gr = conn.Table<Groups>().Where(u => u.num_g == a).FirstOrDefault().id_g;
            var users = conn.Table<Raspis>().ToList();
            if (i == 0)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 2 && (u.id_c == 1 || u.id_c == 3) && u.id_g == gr).ToList();
            if (i == 1)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 3 && (u.id_c == 2 || u.id_c == 3) && u.id_g == gr).ToList();

            foreach (var user in users)
            {
                var time = conn.Table<Times>().FirstOrDefault(r => r.id_t == user.id_t);
                var disc = conn.Table<Discs>().FirstOrDefault(r => r.id_d == user.id_d);
                var vid = conn.Table<Vidi>().FirstOrDefault(r => r.id_v == user.id_v);
                var user1 = conn.Table<Users>().FirstOrDefault(r => r.id_u == user.id_u);
                user.name_t = time?.name_t;
                user.name_d = disc?.name_d;
                user.name_v = vid?.name_v;
                user.fio_u = user1?.fio_u;
            }
            return users;
        }
        public List<Raspis> GetRaspis3(string a, int i)
        {
            int gr = conn.Table<Groups>().Where(u => u.num_g == a).FirstOrDefault().id_g;
            var users = conn.Table<Raspis>().ToList();
            if (i == 0)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 3 && (u.id_c == 1 || u.id_c == 3) && u.id_g == gr).ToList();
            if (i == 1)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 3 && (u.id_c == 2 || u.id_c == 3) && u.id_g == gr).ToList();

            foreach (var user in users)
            {
                var time = conn.Table<Times>().FirstOrDefault(r => r.id_t == user.id_t);
                var disc = conn.Table<Discs>().FirstOrDefault(r => r.id_d == user.id_d);
                var vid = conn.Table<Vidi>().FirstOrDefault(r => r.id_v == user.id_v);
                var user1 = conn.Table<Users>().FirstOrDefault(r => r.id_u == user.id_u);
                user.name_t = time?.name_t;
                user.name_d = disc?.name_d;
                user.name_v = vid?.name_v;
                user.fio_u = user1?.fio_u;
            }
            return users;
        }
        public List<Raspis> GetRaspis4(string a, int i)
        {
            int gr = conn.Table<Groups>().Where(u => u.num_g == a).FirstOrDefault().id_g;
            var users = conn.Table<Raspis>().ToList();
            if (i == 0)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 4 && (u.id_c == 1 || u.id_c == 3) && u.id_g == gr).ToList();
            if (i == 1)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 4 && (u.id_c == 2 || u.id_c == 3) && u.id_g == gr).ToList();

            foreach (var user in users)
            {
                var time = conn.Table<Times>().FirstOrDefault(r => r.id_t == user.id_t);
                var disc = conn.Table<Discs>().FirstOrDefault(r => r.id_d == user.id_d);
                var vid = conn.Table<Vidi>().FirstOrDefault(r => r.id_v == user.id_v);
                var user1 = conn.Table<Users>().FirstOrDefault(r => r.id_u == user.id_u);
                user.name_t = time?.name_t;
                user.name_d = disc?.name_d;
                user.name_v = vid?.name_v;
                user.fio_u = user1?.fio_u;
            }
            return users;
        }
        public List<Raspis> GetRaspis5(string a, int i)
        {
            int gr = conn.Table<Groups>().Where(u => u.num_g == a).FirstOrDefault().id_g;
            var users = conn.Table<Raspis>().ToList();
            if (i == 0)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 5 && (u.id_c == 1 || u.id_c == 3) && u.id_g == gr).ToList();
            if (i == 1)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 5 && (u.id_c == 2 || u.id_c == 3) && u.id_g == gr).ToList();

            foreach (var user in users)
            {
                var time = conn.Table<Times>().FirstOrDefault(r => r.id_t == user.id_t);
                var disc = conn.Table<Discs>().FirstOrDefault(r => r.id_d == user.id_d);
                var vid = conn.Table<Vidi>().FirstOrDefault(r => r.id_v == user.id_v);
                var user1 = conn.Table<Users>().FirstOrDefault(r => r.id_u == user.id_u);
                user.name_t = time?.name_t;
                user.name_d = disc?.name_d;
                user.name_v = vid?.name_v;
                user.fio_u = user1?.fio_u;
            }
            return users;
        }
        public List<Raspis> GetRaspis6(string a, int i)
        {
            int gr = conn.Table<Groups>().Where(u => u.num_g == a).FirstOrDefault().id_g;
            var users = conn.Table<Raspis>().ToList();
            if (i == 0)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 6 && (u.id_c == 1 || u.id_c == 3) && u.id_g == gr).ToList();
            if (i == 1)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 6 && (u.id_c == 2 || u.id_c == 3) && u.id_g == gr).ToList();

            foreach (var user in users)
            {
                var time = conn.Table<Times>().FirstOrDefault(r => r.id_t == user.id_t);
                var disc = conn.Table<Discs>().FirstOrDefault(r => r.id_d == user.id_d);
                var vid = conn.Table<Vidi>().FirstOrDefault(r => r.id_v == user.id_v);
                var user1 = conn.Table<Users>().FirstOrDefault(r => r.id_u == user.id_u);
                user.name_t = time?.name_t;
                user.name_d = disc?.name_d;
                user.name_v = vid?.name_v;
                user.fio_u = user1?.fio_u;
            }
            return users;
        }
        public List<Raspis> GetRaspis11(string a, int i)
        {
            int gr = conn.Table<Users>().Where(u => u.fio_u == a).FirstOrDefault().id_u;
            var users = conn.Table<Raspis>().ToList();
            if (i == 0)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 1 && (u.id_c == 1 || u.id_c == 3) && u.id_u == gr).ToList();
            if (i == 1)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 1 && (u.id_c == 2 || u.id_c == 3) && u.id_u == gr).ToList();

            foreach (var user in users)
            {
                var time = conn.Table<Times>().FirstOrDefault(r => r.id_t == user.id_t);
                var disc = conn.Table<Discs>().FirstOrDefault(r => r.id_d == user.id_d);
                var vid = conn.Table<Vidi>().FirstOrDefault(r => r.id_v == user.id_v);
                user.name_t = time?.name_t;
                user.name_d = disc?.name_d;
                user.name_v = vid?.name_v;
            }
            return users;
        }
        public List<Raspis> GetRaspis22(string a, int i)
        {
            int gr = conn.Table<Users>().Where(u => u.fio_u == a).FirstOrDefault().id_u;
            var users = conn.Table<Raspis>().ToList();
            if (i == 0)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 2 && (u.id_c == 1 || u.id_c == 3) && u.id_u == gr).ToList();
            if (i == 1)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 2 && (u.id_c == 2 || u.id_c == 3) && u.id_u == gr).ToList();

            foreach (var user in users)
            {
                var time = conn.Table<Times>().FirstOrDefault(r => r.id_t == user.id_t);
                var disc = conn.Table<Discs>().FirstOrDefault(r => r.id_d == user.id_d);
                var vid = conn.Table<Vidi>().FirstOrDefault(r => r.id_v == user.id_v);
                user.name_t = time?.name_t;
                user.name_d = disc?.name_d;
                user.name_v = vid?.name_v;
            }
            return users;
        }
        public List<Raspis> GetRaspis33(string a, int i)
        {
            int gr = conn.Table<Users>().Where(u => u.fio_u == a).FirstOrDefault().id_u;
            var users = conn.Table<Raspis>().ToList();
            if (i == 0)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 3 && (u.id_c == 1 || u.id_c == 3) && u.id_u == gr).ToList();
            if (i == 1)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 3 && (u.id_c == 2 || u.id_c == 3) && u.id_u == gr).ToList();

            foreach (var user in users)
            {
                var time = conn.Table<Times>().FirstOrDefault(r => r.id_t == user.id_t);
                var disc = conn.Table<Discs>().FirstOrDefault(r => r.id_d == user.id_d);
                var vid = conn.Table<Vidi>().FirstOrDefault(r => r.id_v == user.id_v);
                user.name_t = time?.name_t;
                user.name_d = disc?.name_d;
                user.name_v = vid?.name_v;
            }
            return users;
        }
        public List<Raspis> GetRaspis44(string a, int i)
        {
            int gr = conn.Table<Users>().Where(u => u.fio_u == a).FirstOrDefault().id_u;
            var users = conn.Table<Raspis>().ToList();
            if (i == 0)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 4 && (u.id_c == 1 || u.id_c == 3) && u.id_u == gr).ToList();
            if (i == 1)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 4 && (u.id_c == 2 || u.id_c == 3) && u.id_u == gr).ToList();

            foreach (var user in users)
            {
                var time = conn.Table<Times>().FirstOrDefault(r => r.id_t == user.id_t);
                var disc = conn.Table<Discs>().FirstOrDefault(r => r.id_d == user.id_d);
                var vid = conn.Table<Vidi>().FirstOrDefault(r => r.id_v == user.id_v);
                user.name_t = time?.name_t;
                user.name_d = disc?.name_d;
                user.name_v = vid?.name_v;
            }
            return users;
        }
        public List<Raspis> GetRaspis55(string a, int i)
        {
            int gr = conn.Table<Users>().Where(u => u.fio_u == a).FirstOrDefault().id_u;
            var users = conn.Table<Raspis>().ToList();
            if (i == 0)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 5 && (u.id_c == 1 || u.id_c == 3) && u.id_u == gr).ToList();
            if (i == 1)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 5 && (u.id_c == 2 || u.id_c == 3) && u.id_u == gr).ToList();

            foreach (var user in users)
            {
                var time = conn.Table<Times>().FirstOrDefault(r => r.id_t == user.id_t);
                var disc = conn.Table<Discs>().FirstOrDefault(r => r.id_d == user.id_d);
                var vid = conn.Table<Vidi>().FirstOrDefault(r => r.id_v == user.id_v);
                user.name_t = time?.name_t;
                user.name_d = disc?.name_d;
                user.name_v = vid?.name_v;
            }
            return users;
        }
        public List<Raspis> GetRaspis66(string a, int i)
        {
            int gr = conn.Table<Users>().Where(u => u.fio_u == a).FirstOrDefault().id_u;
            var users = conn.Table<Raspis>().ToList();
            if (i == 0)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 6 && (u.id_c == 1 || u.id_c == 3) && u.id_u == gr).ToList();
            if (i == 1)
                users = conn.Table<Raspis>().OrderBy(u => u.id_t).Where(u => u.id_n == 6 && (u.id_c == 2 || u.id_c == 3) && u.id_u == gr).ToList();

            foreach (var user in users)
            {
                var time = conn.Table<Times>().FirstOrDefault(r => r.id_t == user.id_t);
                var disc = conn.Table<Discs>().FirstOrDefault(r => r.id_d == user.id_d);
                var vid = conn.Table<Vidi>().FirstOrDefault(r => r.id_v == user.id_v);
                user.name_t = time?.name_t;
                user.name_d = disc?.name_d;
                user.name_v = vid?.name_v;
            }
            return users;
        }
    }
}
