using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Municipios.Modelos;

namespace Municipios
{

    class FireHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://xamarinforms-cacad.firebaseio.com/");

        public async Task<List<Users>> GetAllUsers()
        {

            return (await firebase
              .Child("usuarios")
              .OnceAsync<Users>()).Select(item => new Users
              {
                  correo = item.Object.correo,
                  nombre = item.Object.nombre,
                  pass = item.Object.pass,
                  tipo = item.Object.tipo
              }).ToList();
        }

        public async Task<List<Modelos.municipio>> GetAllMun()
        {
           return (await firebase
                    .Child("municipios")
                    .OnceAsync<Modelos.municipio>())
               .Select(item => new Modelos.municipio
              {
                  Altitud = item.Object.Altitud,
                  Cabecera = item.Object.Cabecera,
                  Clima = item.Object.Clima,
                  IGECEM = item.Object.IGECEM,
                  Latitud = item.Object.Latitud,
                  Longitud = item.Object.Longitud,
                  Nombre = item.Object.Nombre,
                  Significado = item.Object.Significado,
                  Superficie = item.Object.Superficie,
                  Elevacion = item.Object.Elevacion,
                  Rio = item.Object.Rio,
                  Cuerpo = item.Object.Cuerpo,
                  MasPoblado = item.Object.MasPoblado,
                  Poblacion = item.Object.Poblacion,
                  MasExtensos = item.Object.MasExtensos,
                  MenosExtensos = item.Object.MenosExtensos,
                  MasIndustria = item.Object.MasIndustria,

              }).ToList();
        }

        public async Task<List<Modelos.zonar>> GetAllZonas()
        {

            return (await firebase
              .Child("zonas")
              .OnceAsync<Modelos.zonar>()).Select(item => new Modelos.zonar
              {
                  ID = item.Object.ID,
                  IGECEM = item.Object.IGECEM,
                  Desastre = item.Object.Desastre,

              }).ToList();
        }

        //Añadir usuario

        public async Task AddUser(String Correo, String Nombre, String Pass, String Tipo)
        {

            await firebase
              .Child("usuarios")
              .PostAsync(new Users() { correo = Correo, nombre = Nombre, pass = Pass, tipo = Tipo });
        }

        public async Task AddMunicipio(Modelos.municipio mun)
        {

            await firebase
              .Child("municipios")
              .PostAsync(mun);
        }

        public async Task AddZonaRiesgo(String id, String IGECEM, String Desastre)
        {
            await firebase
              .Child("zonas")
              .PostAsync(new Modelos.zonar() { ID = id, IGECEM = IGECEM, Desastre = Desastre });
        }


        //Leer usuario
        public async Task<Users> GetUser(String Correo)
        {
            var allPersons = await GetAllUsers();
            await firebase
              .Child("usuarios")
              .OnceAsync<Users>();
            return allPersons.Where(a => a.correo == Correo).FirstOrDefault();
        }

        public async Task<Modelos.municipio> GetMunicipio(String IGECEM)
        {
            var allMunicipios = await GetAllMun();
            await firebase
              .Child("municipios")
              .OnceAsync<Modelos.municipio>();
            return allMunicipios.Where(a => a.IGECEM == IGECEM).FirstOrDefault();
        }

        public async Task<Modelos.zonar> GetZona(String ID)
        {
            var allZonas = await GetAllZonas();
            await firebase
              .Child("zonas")
              .OnceAsync<Modelos.zonar>();
            return allZonas.Where(a => a.ID == ID).FirstOrDefault();
        }

        //Actualizar usuario
        public async Task UpdateUser(string correo, Users reemplazo)
        {
            var toUpdateUser = (await firebase
              .Child("usuarios")
              .OnceAsync<Users>()).Where(a => a.Object.correo == correo).FirstOrDefault();

            await firebase
              .Child("usuarios")
              .Child(toUpdateUser.Key)
              .PutAsync(reemplazo);
        }

        public async Task UpdateMunicipio(string IGECEM, Modelos.municipio reemplazo)
        {
            var toUpdateUser = (await firebase
              .Child("municipios")
              .OnceAsync<Modelos.municipio>()).Where(a => a.Object.IGECEM == IGECEM).FirstOrDefault();

            await firebase
              .Child("municipios")
              .Child(toUpdateUser.Key)
              .PutAsync(reemplazo);
        }

        public async Task UpdateZonaRiesgo(string ID, Modelos.zonar reemplazo)
        {
            var toUpdateUser = (await firebase
              .Child("zonas")
              .OnceAsync<Modelos.zonar>()).Where(a => a.Object.ID == ID).FirstOrDefault();

            await firebase
              .Child("zonas")
              .Child(toUpdateUser.Key)
              .PutAsync(reemplazo);
        }

        //Borrar usuario
        public async Task DeleteUser(String correo)
        {
            var toDeleteUser = (await firebase
              .Child("usuarios")
              .OnceAsync<Users>()).Where(a => a.Object.correo == correo).FirstOrDefault();
            await firebase.Child("usuarios").Child(toDeleteUser.Key).DeleteAsync();

        }

        public async Task DeleteMunicipio(String IGECEM)
        {
            var toDeleteUser = (await firebase
              .Child("municipios")
              .OnceAsync<Modelos.municipio>()).Where(a => a.Object.IGECEM == IGECEM).FirstOrDefault();
            await firebase.Child("municipios").Child(toDeleteUser.Key).DeleteAsync();

        }

        public async Task DeleteZona(String ID)
        {
            var toDeleteUser = (await firebase
              .Child("zonas")
              .OnceAsync<Modelos.zonar>()).Where(a => a.Object.ID == ID).FirstOrDefault();
            await firebase.Child("zonas").Child(toDeleteUser.Key).DeleteAsync();

        }

        //ultimo registo

    }
}

