module.exports = function(grunt) {
	grunt.loadNpmTasks("grunt-typescript");
	grunt.loadNpmTasks("grunt-contrib-watch");
	grunt.loadNpmTasks('grunt-copy');
	grunt.loadNpmTasks('grunt-contrib-clean');
	
	grunt.initConfig({
		typescript: {
			base: {
            	src: ['./client/**/*.ts'],
            	dest: './temp',
            	options: {
                	'module': 'commonjs',
                	target: 'es5',
					sourceMap: true
                }
            }
        },
		copy: {
			main: {
				files: [
					{
						src: ['./temp/**/*.js', './temp/**/*.js.map'],
            			dest: './build/',
						flatten: true,
						expand: true
					}
				]
			}
		},
		clean: [
			'./temp'
		],
		watch: {
			scripts: {
				files: ['./client/**/*.ts'],
				tasks: ['typescript', 'copy', 'clean']
			}
		}
  });
  
  grunt.registerTask("default", ['typescript', 'copy', 'clean', 'watch']);
};

