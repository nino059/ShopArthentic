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
        const response = await paintingService.getAll(1, 20);
        const paintingList = response?.items || response || [];
        setPaintings(Array.isArray(paintingList) ? paintingList : []);
      } catch (err: unknown) {
        console.error(err);
        setError('Không thể tải danh sách tranh.');
      } finally {
        setLoading(false);
      }
    };

    fetchPaintings();
  }, []);

  if (loading) {
    return <div className="text-center py-20 text-lg">Đang tải bộ sưu tập tranh...</div>;
  }

  if (error) {
    return <div className="text-center py-20 text-red-500">{error}</div>;
  }

  if (paintings.length === 0) {
    return <div className="text-center py-20 text-gray-500">Chưa có tranh nào trong bộ sưu tập.</div>;
  }

  return (
    <div className="max-w-7xl mx-auto px-4 py-12">
      <h1 className="text-4xl font-bold text-center mb-2">Bộ Sưu Tập Tranh Nghệ Thuật</h1>
      <p className="text-center text-gray-600 mb-10">Khám phá những tác phẩm nghệ thuật độc đáo</p>

      {/* Grid Tailwind đẹp và responsive */}
      <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5 2xl:grid-cols-6 gap-6">
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