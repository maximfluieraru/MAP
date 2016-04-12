using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using Common.DataTransferObject;
using Common.Exceptions;

namespace BusinessLogicLayer.RoleSupplier
{
    public static class SupplierBll
    {
        /// <summary>
        /// Trouver les furnssieurs
        /// </summary>
        /// <returns>List<Supplier></returns>
        public static List<Supplier> LoadAllSupplier()
        {
            return SupplierDal.LoadAll();
        }

        /// <summary>
        /// Ajouter un furnisseur dans la table 'Supplier' et dans la table 'SitesSupplier'  
        /// </summary>
        /// <param name="sup"></param>
        public static void InsertSupplier(Supplier sup, SiteSupplier ss)
        {
            SupplierDal.Insert(sup);
            ss.sup_id = SupplierDal.LoadAll().Last<Supplier>().sup_id;

            InsertSupplierSite(ss);
        }

        /// <summary>
        /// Ajouter la relation Supplier-Site dans table 'SitesSupplier'
        /// </summary>
        /// <param name="ss"></param>
        public static void InsertSupplierSite(SiteSupplier ss)
        {
            SiteSupplierDal.Insert(ss);
        }

        public static List<SiteSupplier> LoadAllSiteSupplier()
        {
            return SiteSupplierDal.LoadAll();
        }

        /// <summary>
        /// MaJ d'un furnisseur
        /// </summary>
        /// <param name="sup">Supplier</param>
        public static void UpdateSupplier(Supplier sup)
        {
            SupplierDal.Update(sup);
        }

        /// <summary>
        /// Effacer un furnisseur pour un site 
        /// </summary>
        /// <param name="sup_id">UInt32</param>
        public static void DeleteSupplier(UInt32 sup_id, UInt32 sit_id)
        {
            SiteSupplierDal.Delete(sit_id, sup_id);

        }

        /// <summary>
        ///  Trouver les furniseurs pour un site
        /// </summary>
        /// <param name="site">Site</param>
        /// <returns>List<Supplier></returns>
        public static List<Supplier> LoadAllSupplier(Site site)
        {
            List<Supplier> listSup = new List<Supplier>();
            List<SiteSupplier> listSupSit = SiteSupplierDal.LoadAll(site.sit_id);
            foreach (SiteSupplier ss in listSupSit )
            {
                Console.Write(ss.sup_id);
                listSup.Add(SupplierDal.Load(ss.sup_id));
            }

            return listSup;
        }

        /// <summary>
        /// Trouver les furniseurs pour un site
        /// </summary>
        /// <param name="sit_id">UInt32</param>
        /// <returns>List<Supplier></returns>
        public static List<Supplier> LoadAllBySite(UInt32 sit_id)
        {
            List<Supplier> listSup = new List<Supplier>();
            foreach (SiteSupplier ss in SiteSupplierDal.LoadAll(sit_id))
            {
                listSup.Add(SupplierDal.Load(ss.sit_id));
            }

            return listSup;
        }


        /// <summary>
        /// Trouver les produits pour un fournisseur
        /// </summary>
        /// <param name="sup">Supplier</param>
        /// <returns>List<Product></returns>
        public static List<Product> LoadAllProduct(Supplier sup)
        {
            return ProductDal.LoadAll(sup.sup_id);
        }

        /// <summary>
        /// Effacer un produit
        /// </summary>
        /// <param name="prd_id">UInt32</param>
        public static void DeleteProduct(UInt32 prd_id)
        {
            ProductDal.Delete(prd_id);

        }

        /// <summary>
        /// MaJ d'un produit
        /// </summary>
        /// <param name="sup">Product</param>
        public static void UpdateProduct(Product prd)
        {
            ProductDal.Update(prd);
        }

        /// <summary>
        /// Ajouter un produit pour un furnisseur
        /// </summary>
        /// <param name="prd">Product</param>
        public static void InsertProduct(Product prd)
        {
            ProductDal.Insert(prd);           
        }

        /// <summary>
        /// Trouver tout les produits
        /// </summary>
        /// <returns>List<Product></returns>
        public static List<Product> LoadAllProduct()
        {
            return ProductDal.LoadAll();
        }

    }
}
