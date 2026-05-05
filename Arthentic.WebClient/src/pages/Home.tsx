import Hero from '../components/layout/Hero';
import ProductGrid from '../components/product/ProductGrid';

const Home = () => {
  return (
    <>
      <Hero />

      {/* Bộ sưu tập nổi bật */}
      <div className="container py-5">
        <div className="d-flex justify-content-between align-items-end mb-4">
          <h2 className="fw-bold">Bộ sưu tập nổi bật</h2>
          <a href="/shop" className="btn btn-outline-dark">Xem tất cả →</a>
        </div>
        <ProductGrid />
      </div>

      {/* Phần giới thiệu ngắn */}
      <div className="bg-light py-5">
        <div className="container">
          <div className="row text-center">
            <div className="col-md-4">
              <h5>🎨 100+ Họa sĩ</h5>
              <p className="text-muted">Nghệ sĩ tài năng khắp Việt Nam</p>
            </div>
            <div className="col-md-4">
              <h5>🚚 Giao hàng toàn quốc</h5>
              <p className="text-muted">Miễn phí nội thành TP.HCM và Hà Nội</p>
            </div>
            <div className="col-md-4">
              <h5>🔄 Đổi trả dễ dàng</h5>
              <p className="text-muted">Trong vòng 7 ngày</p>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Home;