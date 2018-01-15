        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Image imageModel)
        {
            string fileName      = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extenstion    = Path.GetExtension(imageModel.ImageFile.FileName);
            fileName             = fileName + DateTime.Now.ToString("yymmssfff") + extenstion;
            imageModel.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            imageModel.ImageFile.SaveAs(fileName);
            /*
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Images.Add(imageModel);
                db.SaveChanges();
            }*/

            ModelState.Clear();
            return View();
        }