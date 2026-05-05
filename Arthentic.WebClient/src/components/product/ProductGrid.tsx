import { useEffect, useState } from 'react';
import ProductCard from './ProductCard';
import { paintingService } from '../../services/paintingService';
import type { Painting } from '../../types/painting'; 

const ProductGrid = () => {
  const [paintings, setPaintings] = useState<Painting[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string>('');

  useEffect(() => {
    const fetchPaintings = async () => {
      try {
        setLoading(true);
        setError('');

        const response = await paintingService.getAll(1, 16);
        const paintingList = response?.items || response || [];

        setPaintings(Array.isArray(paintingList) ? paintingList : []);
      } catch (err: unknown) {
        console.error(err);
        setError('Không thể tải danh sách tranh từ server.');
      } finally {
        setLoading(false);
      }
    };

    fetchPaintings();
  }, []);

  if (loading) {
    return (
      <div className="text-center py-20">
        <div className="spinner-border text-primary mb-3" role="status"></div>
        <p className="text-muted">Đang tải bộ sưu tập tranh...</p>
      </div>
    );
  }

  if (error) {
    return <div className="alert alert-danger text-center py-10">{error}</div>;
  }

  if (paintings.length === 0) {
    return <div className="text-center py-20 text-muted">Chưa có tranh nào.</div>;
  }

  return (
    <div className="container mx-auto px-4 py-8">
      <h2 className="text-center mb-8 text-4xl font-bold text-gray-800">
        Bộ Sưu Tập Tranh Nghệ Thuật
      </h2>

      <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5 gap-6">
        {paintings.map((painting) => (
          <ProductCard
            key={painting.id}
            id={painting.id}
            title={painting.title}
            price={painting.price}
            //discountPrice={painting.discountPrice}
            imageUrl={painting.mainImageUrl || 'https://picsum.photos/id/1015/600/600'}
            artistName={painting.artistName || 'Nghệ sĩ'}
          />
        ))}
      </div>
    </div>
  );
};

export default ProductGrid;