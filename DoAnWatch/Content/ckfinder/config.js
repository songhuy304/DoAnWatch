/*
Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://cksource.com/ckfinder/license
*/

CKFinder.customConfig = function( config )
{
	config.enterMode = CKEDITOR.ENTER_BR;
	config.toolbar = 'Full';

	config.filebrowserBrowseUrl = '/Content/ckfinder/ckfinder.html'
	config.filebrowserImageBrowseUrl = "/Content/ckfinder/ckfinder.html?type=Images";
	config.filebrowserFlashBrowseUrl = "/Content/ckfinder/ckfinder.html?type=Flash";
	config.filebrowserUploadUrl = "/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
	config.filebrowserImageUploadUrl = "/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
	config.filebrowserFlashUploadUrl = "/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";
	config.filebrowserWindowWith = '1000'
	// Define changes to default configuration here.
	// For the list of available options, check:
	// http://docs.cksource.com/ckfinder_2.x_api/symbols/CKFinder.config.html

	// Sample configuration options:
	//config.uiColor = '#BDE31E';
	//config.language = 'vi';
	//config.removePlugins = 'basket';

};
