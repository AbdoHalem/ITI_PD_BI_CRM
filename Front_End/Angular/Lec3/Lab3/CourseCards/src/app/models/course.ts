export interface Course {
  id: number;
  title: string;
  instructor: string;
  price: number;
  seats: number;
  image: string;     // Variable starts with a small letter
  catId: number;
  category: string;  // Added for filtering
}
