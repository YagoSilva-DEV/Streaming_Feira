using System;
using System.Collections.Generic;
using System.IO;

namespace Streamall.Helpers
{
    public static class FavoritesStorage
    {
        private static readonly string FolderPath =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Streamall");

        private static readonly string FilePath =
            Path.Combine(FolderPath, "favorites.txt");

        public static List<int> LoadFavoriteIds()
        {
            List<int> ids = new List<int>();

            if (!File.Exists(FilePath))
            {
                return ids;
            }

            foreach (string line in File.ReadAllLines(FilePath))
            {
                int id;

                if (int.TryParse(line, out id) && !ids.Contains(id))
                {
                    ids.Add(id);
                }
            }

            return ids;
        }

        public static bool AddFavorite(int contentId)
        {
            List<int> ids = LoadFavoriteIds();

            if (ids.Contains(contentId))
            {
                return false;
            }

            Directory.CreateDirectory(FolderPath);
            ids.Add(contentId);

            List<string> lines = new List<string>();

            foreach (int id in ids)
            {
                lines.Add(id.ToString());
            }

            File.WriteAllLines(FilePath, lines.ToArray());

            return true;
        }

        public static void RemoveFavorite(int contentId)
        {
            List<int> ids = LoadFavoriteIds();

            if (!ids.Contains(contentId))
            {
                return;
            }

            ids.Remove(contentId);

            List<string> lines = new List<string>();

            foreach (int id in ids)
            {
                lines.Add(id.ToString());
            }

            Directory.CreateDirectory(FolderPath);
            File.WriteAllLines(FilePath, lines.ToArray());
        }
    }
}
