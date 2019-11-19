import { IArticleCategory } from './article-category';

export interface ITutorial {
  id: number;
  title: string;
  url: string;
  row: number;
  content: string;
  picture: string;
  like: number;
  createdDate: Date;
  updateDate: Date;
  articleCategory: IArticleCategory;
  postCategory: string;
  comment: string;
  brainStormUser: string;
}
