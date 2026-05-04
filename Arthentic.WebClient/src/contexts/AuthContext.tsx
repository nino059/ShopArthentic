import { createContext, useContext, useState, type ReactNode } from 'react';

type Role = 'user' | 'admin' | null;

interface AuthContextType {
  user: { name: string; role: Role; token?: string } | null;
  login: (username: string, password: string) => Promise<boolean>;
  register: (username: string, password: string, fullName?: string) => Promise<boolean>;
  logout: () => void;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider = ({ children }: { children: ReactNode }) => {
  const [user, setUser] = useState<{ name: string; role: Role; token?: string } | null>(null);

  const login = async (username: string, password: string): Promise<boolean> => {
    try {
      // Gọi API backend
      const response = await fetch('https://localhost:7143/api/Auth/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, password }),
      });

      if (!response.ok) return false;

      const data = await response.json();
      
      const role = username.toLowerCase().startsWith('admin') ? 'admin' : 'user';
      
      setUser({
        name: data.fullName || username,
        role: role,
        token: data.token,
      });

      // Lưu token vào localStorage
      localStorage.setItem('token', data.token);
      return true;
    } catch (error) {
      console.error(error);
      return false;
    }
  };

  const register = async (username: string, password: string, fullName?: string): Promise<boolean> => {
    try {
      const response = await fetch('https://localhost:7143/api/Auth/register', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, password, fullName }),
      });

      return response.ok;
    } catch (error) {
      console.error(error);
      return false;
    }
  };

  const logout = () => {
    setUser(null);
    localStorage.removeItem('token');
  };

  return (
    <AuthContext.Provider value={{ user, login, register, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) throw new Error('useAuth must be used within AuthProvider');
  return context;
};