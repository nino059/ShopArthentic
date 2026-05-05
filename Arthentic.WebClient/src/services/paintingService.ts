import api from '../lib/axios';
import type { Painting } from '../types/painting';

export const paintingService = {
  getAll: async (): Promise<Painting[]> => {
    const response = await api.get('/api/Paintings');
    return response.data;
  },

  getFeatured: async (): Promise<Painting[]> => {
    const response = await api.get('/api/Paintings/featured');
    return response.data;
  },

  getById: async (id: string): Promise<Painting> => {
    const response = await api.get(`/api/Paintings/${id}`);
    return response.data;
  },
};