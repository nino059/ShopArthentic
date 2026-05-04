const Footer = () => {
  return (
    <footer className="bg-dark text-light py-5 mt-auto">
      <div className="container">
        <div className="row">
          <div className="col-lg-4 mb-4">
            <div className="d-flex align-items-center mb-3">
              <span className="fs-3 me-2">🎨</span>
              <span className="fw-bold fs-4">Arthentic</span>
            </div>
            <p className="small">Nền tảng nghệ thuật dành cho những bức tranh chân thực từ họa sĩ </p>
          </div>
          <div className="col-lg-2 col-6">
            <h6 className="fw-bold mb-3">Khám phá</h6>
            <ul className="list-unstyled small">
              <li><a href="#" className="text-light text-decoration-none">Cửa hàng</a></li>
              <li><a href="#" className="text-light text-decoration-none">Họa sĩ</a></li>
            </ul>
          </div>
          <div className="col-lg-2 col-6">
            <h6 className="fw-bold mb-3">Hỗ trợ</h6>
            <ul className="list-unstyled small">
              <li><a href="#" className="text-light text-decoration-none">Liên hệ</a></li>
              <li><a href="#" className="text-light text-decoration-none">Chính sách</a></li>
            </ul>
          </div>
          <div className="col-lg-4">
            <h6 className="fw-bold mb-3">Theo dõi chúng tôi</h6>
            <p className="small">Facebook • Instagram • TikTok • YouTube</p>
          </div>
        </div>
        <hr className="my-4" />
        <div className="text-center small">
          © 2026 Arthentic. All rights reserved.
        </div>
      </div>
    </footer>
  );
};

export default Footer;