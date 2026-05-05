import { useEffect, useState } from 'react';
import ProductCard from './ProductCard';
import { paintingService } from '../../services/paintingService';
import type { Painting } from '../../types/painting'; 

const ProductGrid = () => {
  const [paintings, setPaintings] = useState<Painting[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {
    const fetchPaintings = async () => {
      try {
        setLoading(true);
        const data = await paintingService.getAll();
        setPaintings(data);
        setError('');
      } catch (err: any) {
        console.error(err);
        setError('Không thể tải danh sách tranh. Vui lòng kiểm tra backend.');
      } finally {
        setLoading(false);
      }
    };

    fetchPaintings();
  }, []);

  if (loading) {
    return <div className="text-center py-10">Đang tải tranh...</div>;
  }

  if (error) {
    return <div className="text-center py-10 text-red-600">{error}</div>;
  }

  if (paintings.length === 0) {
    return <div className="text-center py-10">Chưa có tranh nào. Vui lòng thêm dữ liệu.</div>;
  }

  return (
    <div className="row g-4">
      {paintings.map(painting => (
        <div key={painting.id} className="col-md-6 col-lg-3">
          <ProductCard
            id={painting.id}
            title={painting.title}
            price={painting.price}
            imageUrl={painting.imageUrl || 'https://picsum.photos/id/1015/600/600'}
            artistName={painting.artistName || 'Không rõ'}
          />
        </div>
      ))}
    </div>
  );
};

export default ProductGrid;