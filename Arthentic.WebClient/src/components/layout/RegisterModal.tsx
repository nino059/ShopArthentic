import { useState } from 'react';
import { useAuth } from '../../contexts/AuthContext';

const RegisterModal = ({ show, onClose }: { show: boolean; onClose: () => void }) => {
  const { register } = useAuth();
  const [formData, setFormData] = useState({
    username: '',
    fullName: '',
    email: '',
    password: '',
    confirmPassword: '',
  });
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');
  const [success, setSuccess] = useState(false);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');
    setSuccess(false);

    if (formData.password !== formData.confirmPassword) {
      setError('Mật khẩu xác nhận không khớp!');
      return;
    }

    setLoading(true);

    const successReg = await register(formData.username, formData.password, formData.fullName);

    if (successReg) {
      setSuccess(true);
      setTimeout(() => {
        onClose();
        alert('Đăng ký thành công! Bạn có thể đăng nhập ngay bây giờ.');
      }, 1200);
    } else {
      setError('Đăng ký thất bại. Tài khoản đã tồn tại hoặc thông tin không hợp lệ.');
    }

    setLoading(false);
  };

  if (!show) return null;

  return (
    <div className="modal show d-block" tabIndex={-1} style={{ backgroundColor: 'rgba(0,0,0,0.6)' }}>
      <div className="modal-dialog modal-dialog-centered">
        <div className="modal-content rounded-4 shadow">
          <div className="modal-header border-0">
            <h4 className="modal-title fw-bold">Đăng ký tài khoản</h4>
            <button type="button" className="btn-close" onClick={onClose}></button>
          </div>
          <div className="modal-body px-4 pb-4">
            <form onSubmit={handleSubmit}>
              <div className="mb-3">
                <label className="form-label fw-medium">Họ và tên</label>
                <input type="text" name="fullName" className="form-control" value={formData.fullName} onChange={handleChange} required />
              </div>
              <div className="mb-3">
                <label className="form-label fw-medium">Tên tài khoản</label>
                <input type="text" name="username" className="form-control" value={formData.username} onChange={handleChange} required />
              </div>
              <div className="mb-3">
                <label className="form-label fw-medium">Email</label>
                <input type="email" name="email" className="form-control" value={formData.email} onChange={handleChange} required />
              </div>
              <div className="mb-3">
                <label className="form-label fw-medium">Mật khẩu</label>
                <input type="password" name="password" className="form-control" value={formData.password} onChange={handleChange} required />
              </div>
              <div className="mb-4">
                <label className="form-label fw-medium">Nhập lại mật khẩu</label>
                <input type="password" name="confirmPassword" className="form-control" value={formData.confirmPassword} onChange={handleChange} required />
              </div>

              {error && <div className="alert alert-danger py-2 small">{error}</div>}
              {success && <div className="alert alert-success py-2">Đăng ký thành công!</div>}

              <button type="submit" className="btn btn-dark btn-lg w-100" disabled={loading}>
                {loading ? 'Đang xử lý...' : 'Tạo tài khoản'}
              </button>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
};
export default RegisterModal;