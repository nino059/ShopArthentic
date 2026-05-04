import { Link } from 'react-router-dom';

const Hero = () => {
  return (
    <div className="position-relative" style={{ height: '90vh', backgroundImage: "url('https://picsum.photos/id/1015/1920/1080')", backgroundSize: 'cover', backgroundPosition: 'center' }}>
      <div className="position-absolute top-0 start-0 w-100 h-100 bg-dark bg-opacity-50"></div>
      <div className="position-relative h-100 d-flex align-items-center justify-content-center text-center text-white">
        <div className="container">
          <h1 className="display-3 fw-bold mb-4">Nghệ Thuật Chân Thực</h1>
          <p className="lead mb-5">Mỗi bức tranh là một câu chuyện từ trái tim họa sĩ</p>
          <div className="d-flex justify-content-center gap-3">
            <Link to="/shop" className="btn btn-light btn-lg px-5">Khám phá ngay</Link>
            <Link to="/artists" className="btn btn-outline-light btn-lg px-5">Gặp họa sĩ</Link>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Hero;