using System;
using System.Collections.Generic;

using UnityEngine;

namespace Assets.Scripts.MaterialsRegistry
{
    /// <summary>
    /// Singleton Class for storing and accessing materials at runtime
    /// </summary>
    public class MaterialsRegistry
    {
        /// <summary>
        /// Class that represents a material entry in the Materials Registry
        /// </summary>
        public class MaterialEntry
        {
            private String m_materialName = "";
            public String MaterialName
            {
                set { m_materialName = value; }
                get { return m_materialName; }
            }

            Material m_materialData = null;
            public Material MaterialData
            {
                set { m_materialData = value; }
                get { return m_materialData; }
            }

            /// <summary>
            /// Copy Constructor
            /// </summary>
            /// <remarks>
            /// Deep copy of MaterialEntry object
            /// </remarks>
            /// <param name="materialEntry"></param>
            public MaterialEntry(MaterialEntry materialEntry)
            {
                MaterialName = materialEntry.MaterialName;
                MaterialData = new Material(materialEntry.MaterialData);
            }

            public MaterialEntry(String name, Material material)
            {
                MaterialName = name;
                MaterialData = new Material(material);
            }

            public MaterialEntry()
            {
                MaterialName = "";
                MaterialData = null;
            }
        }

        // Singleton Instance Object
        private static object lock_object = new object();
        private static MaterialsRegistry m_instance = null;

        // Material Entry Registry
        Dictionary<String, MaterialEntry> m_materialRegistry = null;

        /// <summary>
        /// Private Singleton Constructor
        /// </summary>
        private MaterialsRegistry()
        {
            m_materialRegistry = new Dictionary<string, MaterialEntry>();
        }

        /// <summary>
        /// Public Static Singleton Accessor Method
        /// </summary>
        /// <returns></returns>
        public static MaterialsRegistry GetInstance()
        {
            if (m_instance == null)
            {
                lock(lock_object)
                {
                    if(m_instance == null)
                    {
                        m_instance = new MaterialsRegistry();
                    }
                }
            }

            return m_instance;
        }

        /// <summary>
        /// Method for adding material entries to the registry
        /// </summary>
        /// <returns>True on success, False otherwise</returns>
        public bool AddMaterialEntry(MaterialEntry materialEntry)
        {
            bool result = false;

            if(
               materialEntry != null &&
               materialEntry.MaterialName != null &&
               materialEntry.MaterialName != "" &&
               materialEntry.MaterialData != null &&
               !m_materialRegistry.ContainsKey(materialEntry.MaterialName)
               )
            {
                m_materialRegistry.Add(materialEntry.MaterialName, materialEntry);

                result = true;
            }

            return result;
        }

        /// <summary>
        /// Method for removing material entries from the registry
        /// </summary>
        /// <param name="materialEntry"></param>
        /// <returns></returns>
        public bool RemoveMaterialEntry(MaterialEntry materialEntry)
        {
            bool result = false;

            if (
               materialEntry != null &&
               materialEntry.MaterialName != null &&
               materialEntry.MaterialName != "" &&
               materialEntry.MaterialData != null
               )
            {
                if(m_materialRegistry.ContainsKey(materialEntry.MaterialName))
                {
                    // Remove the Material Entry from the registry
                    result = m_materialRegistry.Remove(materialEntry.MaterialName);

                    result = true;
                }
                else
                {
                    // No Op: Material Entry does not exist in registry
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Method for getting material entries from the registry
        /// </summary>
        /// <returns>True on success, False otherwise</returns>
        /// <param name="materialEntry"></param>
        public bool GetMaterialEntry(ref MaterialEntry materialEntry)
        {
            bool result = false;

            if(materialEntry.MaterialName != null)
            {
                MaterialEntry matEntry;
                result = m_materialRegistry.TryGetValue(materialEntry.MaterialName, out matEntry);

                if(result)
                {
                    materialEntry = matEntry;
                }
                else
                {
                    materialEntry.MaterialData = null;
                }
            }

            return result;
        }

        /// <summary>
        /// Method for getting a deep copy collection of all material entries in the registry
        /// </summary>
        /// <param name="materialEntries"></param>
        public void GetMaterialEntries(out List<MaterialEntry> materialEntries)
        {
            materialEntries = new List<MaterialEntry>();

            // Reference collection of all registry material entries
            Dictionary<String, MaterialEntry>.ValueCollection valueCollection = m_materialRegistry.Values;

            // Deep copy each Material Entry to the returned collection
            foreach(MaterialEntry entry in valueCollection)
            {
                materialEntries.Add(new MaterialEntry(entry));
            }
        }
    }
}
