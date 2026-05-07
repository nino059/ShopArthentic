import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import axios from 'axios';

const ProductDetail = () => {
  const { id } = useParams<{ id: string }>();
  const [painting, setPainting] = useState<{
    mainImageUrl?: string;
    images?: string[];
    title?: string;
    artistName?: string;
    price?: number;
    description?: string;
  } | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchDetail = async () => {
      if (!id) {
        setError('Thiếu id tranh');
        setLoading(false);
        return;
      }

      try {
        setLoading(true);
        setError(null);

        const res = await axios.get(`/api/paintings/${id}`);
        setPainting(res.data);
      } catch (err: unknown) {
        const status = (err as { response?: { status: number } })?.response?.status;
        if (status === 404) setError('Không tìm thấy tranh');
        else if (status === 500) setError('Lỗi server khi tải chi tiết tranh');
        else setError('Không thể kết nối với server. Backend có đang chạy không?');
      } finally {
        setLoading(false);
      }
    };

    fetchDetail();
  }, [id]);

  if (loading) return <div className="text-center py-20 text-xl">Đang tải chi tiết tranh...</div>;
  if (error) return <div className="text-center py-20 text-red-600 text-lg">{error}</div>;
  if (!painting) return <div className="text-center py-20">Không tìm thấy tranh</div>;

  return (
    <div className="max-w-6xl mx-auto px-6 py-12">
      <div className="grid grid-cols-1 lg:grid-cols-2 gap-12">
        <div>
          <img
            src={painting.mainImageUrl || painting.images?.[0] || 'https://picsum.photos/800/600'}
            alt={painting.title || 'Painting'}
            className="w-full rounded-3xl shadow-xl"
          />
        </div>

        <div>
          <h1 className="text-4xl font-bold">{painting.title || 'Không có tiêu đề'}</h1>
          <p className="text-xl text-gray-600 mt-2">
            bởi <span className="font-semibold">{painting.artistName || 'Chưa rõ'}</span>
          </p>

          <div className="mt-6 text-4xl font-bold text-red-600">
            {painting.price ? painting.price.toLocaleString('vi-VN') : '0'} ₫
          </div>

          <div className="mt-8 text-gray-700 leading-relaxed">
            {painting.description || 'Chưa có mô tả'}
          </div>

          <button className="mt-10 w-full bg-black text-white py-5 rounded-2xl text-lg font-semibold">
            Thêm vào giỏ hàng
          </button>
        </div>
      </div>
    </div>
  );
};

export default ProductDetail;