import { useAuth } from '../contexts/AuthContext';

const Profile = () => {
  const { user } = useAuth();

  return (
    <div className="container py-5">
      <h1 className="fw-bold mb-4">Hồ sơ cá nhân</h1>
      {user ? (
        <div className="card">
          <div className="card-body">
            <h4>Tên: {user.name}</h4>
            <p>Vai trò: {user.role === 'admin' ? 'Quản lý' : 'Người mua'}</p>
            <p>Email: example@email.com</p>
          </div>
        </div>
      ) : (
        <p>Bạn chưa đăng nhập.</p>
      )}
    </div>
  );
};

export default Profile;