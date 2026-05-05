import { ShoppingCart, User, Search } from 'lucide-react';
import { Link } from 'react-router-dom';
import { useAuth } from '../../contexts/AuthContext';
import { useState } from 'react';
import LoginModal from './LoginModal';
import RegisterModal from './RegisterModal';

const Navbar = () => {
  const { user, logout } = useAuth();
  const [showLogin, setShowLogin] = useState(false);
  const [showRegister, setShowRegister] = useState(false);

  return (
    <>
      <nav className="navbar navbar-expand-lg navbar-light bg-white shadow-sm sticky-top">
        <div className="container">
          <Link className="navbar-brand d-flex align-items-center" to="/">
            <span className="fs-3 me-2">🎨</span>
            <span className="fw-bold">Arthentic</span>
          </Link>

          <div className="collapse navbar-collapse" id="navbarNav">
            <ul className="navbar-nav mx-auto">
              <li className="nav-item"><Link className="nav-link" to="/">Trang chủ</Link></li>
              <li className="nav-item"><Link className="nav-link" to="/shop">Cửa hàng</Link></li>
              <li className="nav-item"><Link className="nav-link" to="/artists">Họa sĩ</Link></li>
              <li className="nav-item"><Link className="nav-link" to="/about">Về chúng tôi</Link></li>
            </ul>

            <div className="d-flex align-items-center gap-3">
              <div className="input-group" style={{ width: '260px' }}>
                <span className="input-group-text"><Search size={18} /></span>
                <input type="text" className="form-control" placeholder="Tìm tranh..." />
              </div>

              <Link to="/cart" className="position-relative">
                <ShoppingCart size={24} />
              </Link>

              {user ? (
                <div className="dropdown">
                  <button className="btn btn-light dropdown-toggle d-flex align-items-center gap-2" data-bs-toggle="dropdown">
                    <User size={20} />
                    <span>{user.name}</span>
                  </button>
                  <ul className="dropdown-menu dropdown-menu-end">
                    <li><Link className="dropdown-item" to="/profile">Hồ sơ</Link></li>
                    {user.role === 'admin' && <li><Link className="dropdown-item" to="/admin">Quản lý Admin</Link></li>}
                    <li><hr className="dropdown-divider" /></li>
                    <li><button className="dropdown-item text-danger" onClick={logout}>Đăng xuất</button></li>
                  </ul>
                </div>
              ) : (
                <div className="btn-group">
                  <button 
                    className="btn btn-outline-dark px-4"
                    onClick={() => setShowLogin(true)}
                  >
                    Đăng nhập
                  </button>
                  <button 
                    className="btn btn-dark px-4"
                    onClick={() => setShowRegister(true)}
                  >
                    Đăng ký
                  </button>
                </div>
              )}
            </div>
          </div>
        </div>
      </nav>

      <LoginModal show={showLogin} onClose={() => setShowLogin(false)} />
      <RegisterModal show={showRegister} onClose={() => setShowRegister(false)} />
    </>
  );
};

export default Navbar;