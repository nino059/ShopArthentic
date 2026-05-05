import api from './api';

export const paintingService = {
  // Lấy tất cả tranh (có phân trang)
  getAll: async (page: number = 1, pageSize: number = 12) => {
    const response = await api.get(`/api/paintings?page=${page}&pageSize=${pageSize}`);
    return response.data;
  },

  // Lấy tranh nổi bật
  getFeatured: async () => {
    const response = await api.get('/api/paintings/featured');
    return response.data;
  },

  // Lấy chi tiết một tranh
  getById: async (id: string) => {
    const response = await api.get(`/api/paintings/${id}`);
    return response.data;
  }
};