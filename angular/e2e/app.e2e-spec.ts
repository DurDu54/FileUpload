import { FileUploadTemplatePage } from './app.po';

describe('FileUpload App', function() {
  let page: FileUploadTemplatePage;

  beforeEach(() => {
    page = new FileUploadTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
