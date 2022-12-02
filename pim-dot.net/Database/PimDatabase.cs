using MySqlConnector;
using pim_paulista.Models;

namespace pim_paulista.Database
{
    public class PimDatabase
    {
        public List<UsuariosDTO> GetAllUsers(string usuario, string senha)
        {
            string script = "Select * from tb_Usuarios where nm_Usuarios like @nm_Usuarios and ds_Senhas like @ds_Senhas";

            List<MySqlParameter> credencials = new List<MySqlParameter>();
            credencials.Add(new MySqlParameter("nm_Usuarios", "%" + usuario + "%"));
            credencials.Add(new MySqlParameter("ds_Senhas", "%" + senha + "%"));   

            UnipDataBase conn = new UnipDataBase();
            MySqlDataReader reader = conn.ExecuteSelect(script, credencials);

            List<UsuariosDTO> usuarios = new List<UsuariosDTO>();

            while (reader.Read())
            {
                UsuariosDTO user = new UsuariosDTO();

                user.id_Usuarios = reader.GetInt32("id_Usuarios");
                user.id_Cargo = reader.GetInt32("id_Cargo");
                user.id_Info = reader.GetInt32("id_Info");
                user.nm_Usuarios = reader.GetString("nm_Usuarios");
                user.ds_Senhas = reader.GetString("ds_Senhas");
                user.dt_LastedOn = reader.GetDateTime("dt_LastedOn");
                user.dt_UpdatedOn = reader.GetDateTime("dt_UpdatedOn");
                user.dt_CreatedOn = reader.GetDateTime("dt_CreatedOn");

                usuarios.Add(user);
            }

            return usuarios;
        }

        public int SaveInfo(InfosDTO obj)
        {
            string query = "insert into tb_Info (nm_Completo, ds_Endereco, nm_Numero, ds_Cpf, ds_Cep, ds_Formacao, ds_Tel, ds_Cel, dt_Aniv, dt_UpdateOn) VALUES (@nm_Completo, @ds_Endereco, @nm_Numero, @ds_Cpf, @ds_Cep, @ds_Formacao, @ds_Tel, @ds_Cel, @dt_Aniv, @dt_UpdateOn)";

            List<MySqlParameter> param = new List<MySqlParameter>();
            param.Add(new MySqlParameter("nm_Completo", obj.nm_Completo));
            param.Add(new MySqlParameter("ds_Endereco", obj.ds_Endereco));
            param.Add(new MySqlParameter("nm_Numero", obj.nm_Numero));
            param.Add(new MySqlParameter("ds_Cpf", obj.ds_Cpf));
            param.Add(new MySqlParameter("ds_Cep", obj.ds_Cep));
            param.Add(new MySqlParameter("ds_Formacao", obj.ds_Formacao));
            param.Add(new MySqlParameter("ds_Tel", obj.ds_Tel));
            param.Add(new MySqlParameter("ds_Cel", obj.ds_Cel));
            param.Add(new MySqlParameter("dt_Aniv", obj.dt_Aniv));
            param.Add(new MySqlParameter("dt_UpdateOn", obj.dt_UpdateOn));

            UnipDataBase conn = new UnipDataBase();
            return conn.ExecuteScalar(query, param);
        }

        public void SaveUsuarios(UsuariosDTO obj)
        {
            string query = "insert into tb_Usuarios (id_Cargo, id_Info, nm_Usuarios, ds_Senhas, dt_LastedOn, dt_UpdatedOn, dt_CreatedOn) VALUES (@id_Cargo, @id_Info, @nm_Usuarios, @ds_Senhas, @dt_LastedOn, @dt_UpdatedOn, @dt_CreatedOn)";

            List<MySqlParameter> param = new List<MySqlParameter>();
            param.Add(new MySqlParameter("id_Cargo", obj.id_Cargo));
            param.Add(new MySqlParameter("id_Info", obj.id_Info));
            param.Add(new MySqlParameter("nm_Usuarios", obj.nm_Usuarios));
            param.Add(new MySqlParameter("ds_Senhas", obj.ds_Senhas));
            param.Add(new MySqlParameter("dt_LastedOn", obj.dt_LastedOn));
            param.Add(new MySqlParameter("dt_UpdatedOn", obj.dt_UpdatedOn));
            param.Add(new MySqlParameter("dt_CreatedOn", obj.dt_CreatedOn));

            UnipDataBase conn = new UnipDataBase();
            conn.ExecuteInsert(query, param);
        }

        public List<CargosDTO> GetRole(int id_Cargo)
        {
            string script = "Select * from tb_Cargos where id_Cargo like @id_Cargo;";

            List<MySqlParameter> param = new List<MySqlParameter>();
            param.Add(new MySqlParameter("id_Cargo", "%" + id_Cargo + "%"));

            UnipDataBase conn = new UnipDataBase();
            MySqlDataReader reader = conn.ExecuteSelect(script, param);

            List<CargosDTO> role = new List<CargosDTO>();

            while (reader.Read())
            {
                CargosDTO cargos = new CargosDTO();

                cargos.id_Cargo = reader.GetInt32("id_Cargo");
                cargos.ds_Cargo = reader.GetString("ds_Cargo");
                cargos.dt_CreatedOn = reader.GetDateTime("dt_CreatedOn");

                role.Add(cargos);
            }


            return role;
        }

        public List<InfosDTO> GetInfo(int id_Info)
        {
            string script = "Select * from tb_Usuarios inner join tb_Info ON tb_Usuarios.id_Info = tb_Info.id_Info where tb_Info.id_Info like @id_Info;";

            List<MySqlParameter> param = new List<MySqlParameter>();
            param.Add(new MySqlParameter("id_Info", "%" + id_Info + "%"));

            UnipDataBase conn = new UnipDataBase();
            MySqlDataReader reader = conn.ExecuteSelect(script, param);

            List<InfosDTO> info = new List<InfosDTO>();

            while (reader.Read())
            {
                InfosDTO i = new InfosDTO();

                i.id_Info = reader.GetInt32("id_Info");
                i.nm_Completo = reader.GetString("nm_Completo");
                //i.dt_CreatedOn = reader.GetDateTime("dt_CreatedOn");

                info.Add(i);
            }


            return info;
        }

        public void AttLastedOn(int id_Usuario)
        {
            string script = "update tb_Usuarios set dt_LastedOn = @data where id_Usuarios like @id_Usuarios;";

            List<MySqlParameter> param = new List<MySqlParameter>();
            param.Add(new MySqlParameter("id_Usuarios", id_Usuario));
            param.Add(new MySqlParameter("data", DateTime.Now));
                        
            UnipDataBase conn = new UnipDataBase();
            MySqlDataReader reader = conn.ExecuteSelect(script, param);
        }

        public List<NacionalidadeDTO> LoadingNacionalidade()
        {
            string script = "Select * from tb_Pais;";

            UnipDataBase conn = new UnipDataBase();
            MySqlDataReader reader = conn.ExecuteSelect(script, null);

            List<NacionalidadeDTO> nacionalidade = new List<NacionalidadeDTO>();

            while (reader.Read())
            {
                NacionalidadeDTO i = new NacionalidadeDTO();

                i.id_Pais = reader.GetInt32("id_Pais");
                i.ds_Nome = reader.GetString("ds_Nome");
                i.ds_Name = reader.GetString("ds_Name");

                nacionalidade.Add(i);
            }


            return nacionalidade;

        }
    }
}
