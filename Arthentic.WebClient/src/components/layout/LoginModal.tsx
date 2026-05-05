import { useState } from 'react';
import { useAuth } from '../../contexts/AuthContext';

const LoginModal = ({ show, onClose }: { show: boolean; onClose: () => void }) => {
  const { login } = useAuth();
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);
    setError('');

    const success = await login(username, password);
    if (success) {
      onClose();
    } else {
      setError('Tài khoản hoặc mật khẩu không đúng');
    }
    setLoading(false);
  };

  if (!show) return null;

  return (
    <div className="modal show d-block" tabIndex={-1} style={{ backgroundColor: 'rgba(0,0,0,0.6)' }}>
      <div className="modal-dialog modal-dialog-centered">
        <div className="modal-content rounded-4">
          <div className="modal-header border-0">
            <h4 className="modal-title fw-bold">Đăng nhập</h4>
            <button type="button" className="btn-close" onClick={onClose}></button>
          </div>
          <div className="modal-body px-4">
            <form onSubmit={handleSubmit}>
              <div className="mb-3">
                <label className="form-label fw-medium">Tên tài khoản</label>
                <input
                  type="text"
                  className="form-control form-control-lg"
                  placeholder="Nhập tên tài khoản"
                  value={username}
                  onChange={(e) => setUsername(e.target.value)}
                  required
                />
              </div>
              <div className="mb-4">
                <label className="form-label fw-medium">Mật khẩu</label>
                <input
                  type="password"
                  className="form-control form-control-lg"
                  placeholder="Nhập mật khẩu"
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                  required
                />
              </div>

              {error && <div className="alert alert-danger py-2">{error}</div>}

              <button type="submit" className="btn btn-dark btn-lg w-100" disabled={loading}>
                {loading ? 'Đang đăng nhập...' : 'Đăng nhập'}
              </button>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
};

export default LoginModal;