using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemo2.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;

namespace WebAPIDemo2.Controllers
{
    public class AlbumnsController : ApiController
    {
        private static Band[] bands = new Band[] 
        { 
            new Band() { ID = 1, Name = "Beatles" },
            new Band() { ID = 2, Name = "Oasis" },
            new Band() { ID = 3, Name = "Suede" },
            new Band() { ID = 4, Name = "Blur" } 
        };

        private static Albumn[] albumns = new Albumn[] 
        { 
            // Beatles
            new Albumn() { ID = 1, Name = "Let It Be", Band = bands[0], ReleaseDate = new DateTime(1970, 05, 01) },
            new Albumn() { ID = 2, Name = "Abbey Road", Band = bands[0], ReleaseDate = new DateTime(1969, 09, 01) },
            new Albumn() { ID = 3, Name = "The Beatles(The White Album)", Band = bands[0], ReleaseDate = new DateTime(1968, 11, 01) },

            // Oasis
            new Albumn() { ID = 4, Name = "(What's the Story) Morning Glory?", Band = bands[1], ReleaseDate = new DateTime(1995, 10, 01) },
            new Albumn() { ID = 5, Name = "Definitely Maybe", Band = bands[1], ReleaseDate = new DateTime(1994, 08, 01) } ,
            new Albumn() { ID = 6, Name = "Don't Look Back in Anger", Band = bands[1], ReleaseDate = new DateTime(1996, 2, 01) }, 
            new Albumn() { ID = 7, Name = "The Masterplan", Band = bands[1], ReleaseDate = new DateTime(1998, 11, 01) },

            // Suede
            new Albumn() { ID = 8, Name = "Coming Up", Band = bands[2], ReleaseDate = new DateTime(1997, 04, 01) },
            new Albumn() { ID = 9, Name = "Suede", Band = bands[2], ReleaseDate = new DateTime(1993, 03, 01) } ,

            // Blur
            new Albumn() { ID = 10, Name = "13", Band = bands[3], ReleaseDate = new DateTime(1999, 03, 01) }
        };

        public IEnumerable<Albumn> GetAllAlbumns()
        {
            return albumns.Where(al => al.IsDeleted != true).ToList();
        }

        public IEnumerable<Albumn> GetBlabla(string searchKey)
        {
            searchKey = searchKey.Trim();

            // By ID
            var chosenAlbumns = albumns.Where(a => a.ID.ToString() == searchKey.ToString().ToLower());
            if (chosenAlbumns!=null && chosenAlbumns.Count() > 0) return chosenAlbumns;

            // By BandName
            chosenAlbumns = albumns.Where(a => a.Band.Name.ToLower() == searchKey.ToString().ToLower());
            if (chosenAlbumns != null && chosenAlbumns.Count() > 0) return chosenAlbumns;

            // By Name
            chosenAlbumns = albumns.Where(a => a.Name.Replace(" ", "").ToLower().Contains(searchKey.Replace(" ", "").ToString().ToLower()));
            if (chosenAlbumns != null && chosenAlbumns.Count() > 0) return chosenAlbumns;

            // By Date
            chosenAlbumns = albumns.Where(a => a.ReleaseDate.ToString("yyyyMMdd").Contains(searchKey));
            if (chosenAlbumns != null && chosenAlbumns.Count() > 0) return chosenAlbumns;

            return chosenAlbumns;
        }

        // Delete
        // searchKey here is in route configuration.
        public Albumn DeleteBlabla(int searchKey) 
        {
            Albumn albumn = albumns.Where(al => al.ID == searchKey).FirstOrDefault();

            if (albumn == null) 
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            albumn.IsDeleted = true;
            return albumn;
        }

        //public HttpResponseMessage<Albumn> PostBlabla(Albumn albumn) 
        //{
            
        //}
    }
}
